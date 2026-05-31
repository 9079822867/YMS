using System.Security.Cryptography;
using YMS.Application.DTOs;
using YMS.Application.Interfaces;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;

namespace YMS.Application.Services;

public class ExitService : IExitService
{
    private readonly IExitRepository _exitRepo;
    private readonly IRepository<Vehicle> _vehicleRepo;

    private const int OtpValidMinutes = 30;
    private const int MaxOtpAttempts  = 5;

    public ExitService(IExitRepository exitRepo, IRepository<Vehicle> vehicleRepo)
    {
        _exitRepo = exitRepo;
        _vehicleRepo = vehicleRepo;
    }

    public async Task<IEnumerable<ExitRequestListDto>> GetAllAsync(string? status)
    {
        var all = await _exitRepo.GetAllWithDetailsAsync(status);
        return all.Select(MapToDto);
    }

    public async Task<ExitRequestListDto?> GetByIdAsync(int id)
    {
        var e = await _exitRepo.GetByIdWithDetailsAsync(id);
        return e is null ? null : MapToDto(e);
    }

    public async Task<(bool Success, string Error, int Id)> CreateAsync(CreateExitRequest request, int requestedBy)
    {
        if (!ExitReason.All.Contains(request.ExitReason))
            return (false, $"Invalid exit reason. Valid: {string.Join(", ", ExitReason.All)}", 0);

        var vehicle = await _vehicleRepo.GetByIdAsync(request.VehicleId);
        if (vehicle is null) return (false, "Vehicle not found", 0);
        if (vehicle.ExitDate.HasValue) return (false, "Vehicle has already exited the yard", 0);

        // Block duplicate open requests
        if (await _exitRepo.HasOpenRequestAsync(request.VehicleId))
            return (false, "An exit request is already open for this vehicle", 0);

        var entity = new VehicleExitRequest
        {
            VehicleId       = request.VehicleId,
            RequestedBy     = requestedBy,
            ExitReason      = request.ExitReason,
            ReceiverName    = request.ReceiverName.Trim(),
            ReceiverContact = request.ReceiverContact.Trim(),
            ReceiverIdProof = request.ReceiverIdProof,
            Notes           = request.Notes,
            Status          = ExitStatus.Pending
        };

        await _exitRepo.AddAsync(entity);
        await _exitRepo.SaveChangesAsync();
        return (true, string.Empty, entity.Id);
    }

    public async Task<(bool Success, string Error, OtpIssuedResponse? Otp)> ApproveAsync(int id, ApproveExitRequest request, int approverId)
    {
        var e = await _exitRepo.GetByIdAsync(id);
        if (e is null) return (false, "Exit request not found", null);
        if (e.Status != ExitStatus.Pending)
            return (false, $"Only pending requests can be approved/rejected (current: {e.Status})", null);

        // ── Reject ──
        if (!request.Approve)
        {
            e.Status          = ExitStatus.Rejected;
            e.RejectionReason = request.RejectionReason ?? "Rejected by approver";
            e.ApprovedBy      = approverId;
            e.ApprovedAt      = DateTime.UtcNow;
            e.UpdatedAt       = DateTime.UtcNow;
            _exitRepo.Update(e);
            await _exitRepo.SaveChangesAsync();
            return (true, string.Empty, null);
        }

        // ── Approve → issue OTP ──
        var otp = GenerateOtp();
        var (hash, expiry, gatePass) = (HashOtp(otp), DateTime.UtcNow.AddMinutes(OtpValidMinutes), GenerateGatePass());

        e.Status        = ExitStatus.Approved;
        e.ApprovedBy    = approverId;
        e.ApprovedAt    = DateTime.UtcNow;
        e.OtpHash       = hash;
        e.OtpExpiry     = expiry;
        e.OtpAttempts   = 0;
        e.GatePassCode  = gatePass;
        e.UpdatedAt     = DateTime.UtcNow;

        _exitRepo.Update(e);
        await _exitRepo.SaveChangesAsync();

        return (true, string.Empty, new OtpIssuedResponse
        {
            ExitRequestId = e.Id,
            Otp           = otp,         // shown ONCE
            OtpExpiry     = expiry,
            GatePassCode  = gatePass
        });
    }

    public async Task<(bool Success, string Error)> VerifyOtpAsync(int id, string otp)
    {
        var e = await _exitRepo.GetByIdAsync(id);
        if (e is null) return (false, "Exit request not found");
        if (e.Status != ExitStatus.Approved) return (false, "Exit request is not in an OTP-verifiable state");

        if (e.OtpExpiry is null || e.OtpExpiry < DateTime.UtcNow)
            return (false, "OTP has expired. Please regenerate.");
        if (e.OtpAttempts >= MaxOtpAttempts)
            return (false, "Maximum OTP attempts exceeded. Please regenerate.");

        if (e.OtpHash != HashOtp(otp))
        {
            e.OtpAttempts++;
            e.UpdatedAt = DateTime.UtcNow;
            _exitRepo.Update(e);
            await _exitRepo.SaveChangesAsync();
            return (false, $"Incorrect OTP ({MaxOtpAttempts - e.OtpAttempts} attempt(s) left)");
        }

        // ── Success: complete exit + update vehicle ──
        e.Status        = ExitStatus.Completed;
        e.OtpVerifiedAt = DateTime.UtcNow;
        e.ExitedAt      = DateTime.UtcNow;
        e.OtpHash       = null;            // burn the single-use OTP
        e.UpdatedAt     = DateTime.UtcNow;
        _exitRepo.Update(e);

        var vehicle = await _vehicleRepo.GetByIdAsync(e.VehicleId);
        if (vehicle is not null)
        {
            vehicle.ExitDate      = DateTime.UtcNow;
            vehicle.RunningStatus = ExitReason.ToRunningStatus(e.ExitReason);
            vehicle.UpdatedAt     = DateTime.UtcNow;
            _vehicleRepo.Update(vehicle);
        }

        await _exitRepo.SaveChangesAsync();
        return (true, string.Empty);
    }

    public async Task<(bool Success, string Error, OtpIssuedResponse? Otp)> RegenerateOtpAsync(int id)
    {
        var e = await _exitRepo.GetByIdAsync(id);
        if (e is null) return (false, "Exit request not found", null);
        if (e.Status != ExitStatus.Approved) return (false, "Only approved requests can regenerate OTP", null);

        var otp = GenerateOtp();
        e.OtpHash     = HashOtp(otp);
        e.OtpExpiry   = DateTime.UtcNow.AddMinutes(OtpValidMinutes);
        e.OtpAttempts = 0;
        e.UpdatedAt   = DateTime.UtcNow;
        _exitRepo.Update(e);
        await _exitRepo.SaveChangesAsync();

        return (true, string.Empty, new OtpIssuedResponse
        {
            ExitRequestId = e.Id,
            Otp           = otp,
            OtpExpiry     = e.OtpExpiry.Value,
            GatePassCode  = e.GatePassCode ?? string.Empty
        });
    }

    public async Task<bool> CancelAsync(int id)
    {
        var e = await _exitRepo.GetByIdAsync(id);
        if (e is null) return false;
        if (e.Status == ExitStatus.Completed) return false;  // cannot cancel a finished exit

        e.Status    = ExitStatus.Cancelled;
        e.OtpHash   = null;
        e.UpdatedAt = DateTime.UtcNow;
        _exitRepo.Update(e);
        await _exitRepo.SaveChangesAsync();
        return true;
    }

    // ── Helpers ─────────────────────────────────────────────────
    private static string GenerateOtp()
    {
        // 6-digit cryptographically-strong OTP
        return RandomNumberGenerator.GetInt32(100000, 1000000).ToString();
    }

    private static string HashOtp(string otp)
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes(otp + "|YMS_EXIT_SALT");
        return Convert.ToHexString(SHA256.HashData(bytes));
    }

    private static string GenerateGatePass()
    {
        return "GP-" + DateTime.UtcNow.ToString("yyMMdd") + "-" +
               RandomNumberGenerator.GetInt32(1000, 9999);
    }

    private static ExitRequestListDto MapToDto(VehicleExitRequest e) => new()
    {
        Id                 = e.Id,
        VehicleId          = e.VehicleId,
        RegistrationNumber = e.Vehicle?.RegistrationNumber ?? string.Empty,
        ChassisNumber      = e.Vehicle?.ChassisNumber ?? string.Empty,
        ClientName         = e.Vehicle?.Client?.Name ?? string.Empty,
        YardName           = e.Vehicle?.Yard?.Name ?? string.Empty,
        ExitReason         = e.ExitReason,
        ReceiverName       = e.ReceiverName,
        Status             = e.Status,
        CreatedAt          = e.CreatedAt,
        ApprovedAt         = e.ApprovedAt,
        OtpExpiry          = e.OtpExpiry,
        ExitedAt           = e.ExitedAt,
        GatePassCode       = e.GatePassCode
    };
}
