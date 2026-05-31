using YMS.Application.DTOs;
using YMS.Application.Interfaces;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;

namespace YMS.Application.Services;

public class TransferService : ITransferService
{
    private readonly ITransferRepository _repo;
    private readonly IRepository<Vehicle> _vehicleRepo;

    public TransferService(ITransferRepository repo, IRepository<Vehicle> vehicleRepo)
    {
        _repo = repo;
        _vehicleRepo = vehicleRepo;
    }

    public async Task<IEnumerable<TransferListDto>> GetAllAsync(string? status)
        => (await _repo.GetAllWithDetailsAsync(status)).Select(Map);

    public async Task<IEnumerable<TransferListDto>> GetHistoryAsync(int vehicleId)
        => (await _repo.GetHistoryAsync(vehicleId)).Select(Map);

    public async Task<(bool Success, string Error, int Id)> CreateAsync(CreateTransferRequest request, int userId)
    {
        var vehicle = await _vehicleRepo.GetByIdAsync(request.VehicleId);
        if (vehicle is null) return (false, "Vehicle not found", 0);
        if (vehicle.ExitDate.HasValue) return (false, "Vehicle has exited the yard", 0);
        if (vehicle.YardId == request.ToYardId) return (false, "Vehicle is already in the destination yard", 0);
        if (await _repo.HasOpenAsync(request.VehicleId)) return (false, "An open transfer already exists for this vehicle", 0);

        var t = new VehicleTransfer
        {
            VehicleId   = request.VehicleId,
            FromYardId  = vehicle.YardId,
            ToYardId    = request.ToYardId,
            Reason      = request.Reason,
            Notes       = request.Notes,
            Status      = TransferStatus.Requested,
            RequestedBy = userId
        };
        await _repo.AddAsync(t);
        await _repo.SaveChangesAsync();
        return (true, string.Empty, t.Id);
    }

    public async Task<(bool Success, string Error)> ApproveAsync(int id, bool approve, string? reason, int approverId)
    {
        var t = await _repo.GetByIdAsync(id);
        if (t is null) return (false, "Transfer not found");
        if (t.Status != TransferStatus.Requested) return (false, "Only requested transfers can be approved/rejected");

        t.Status          = approve ? TransferStatus.Approved : TransferStatus.Rejected;
        t.ApprovedBy      = approverId;
        t.ApprovedAt      = DateTime.UtcNow;
        t.RejectionReason = approve ? null : (reason ?? "Rejected");
        t.UpdatedAt       = DateTime.UtcNow;
        _repo.Update(t);
        await _repo.SaveChangesAsync();
        return (true, string.Empty);
    }

    public async Task<(bool Success, string Error)> DispatchAsync(int id)
    {
        var t = await _repo.GetByIdAsync(id);
        if (t is null) return (false, "Transfer not found");
        if (t.Status != TransferStatus.Approved) return (false, "Transfer must be approved before dispatch");

        t.Status       = TransferStatus.Dispatched;
        t.DispatchedAt = DateTime.UtcNow;
        t.UpdatedAt    = DateTime.UtcNow;
        _repo.Update(t);

        // Mark vehicle in-transit
        var vehicle = await _vehicleRepo.GetByIdAsync(t.VehicleId);
        if (vehicle is not null) { vehicle.RunningStatus = "In Transit"; vehicle.UpdatedAt = DateTime.UtcNow; _vehicleRepo.Update(vehicle); }

        await _repo.SaveChangesAsync();
        return (true, string.Empty);
    }

    public async Task<(bool Success, string Error)> ReceiveAsync(int id)
    {
        var t = await _repo.GetByIdAsync(id);
        if (t is null) return (false, "Transfer not found");
        if (t.Status != TransferStatus.Dispatched) return (false, "Transfer must be dispatched before receiving");

        t.Status     = TransferStatus.Received;
        t.ReceivedAt = DateTime.UtcNow;
        t.UpdatedAt  = DateTime.UtcNow;
        _repo.Update(t);

        // Move vehicle to destination yard
        var vehicle = await _vehicleRepo.GetByIdAsync(t.VehicleId);
        if (vehicle is not null)
        {
            vehicle.YardId        = t.ToYardId;
            vehicle.RunningStatus = "Running";
            vehicle.UpdatedAt     = DateTime.UtcNow;
            _vehicleRepo.Update(vehicle);
        }

        await _repo.SaveChangesAsync();
        return (true, string.Empty);
    }

    public async Task<bool> CancelAsync(int id)
    {
        var t = await _repo.GetByIdAsync(id);
        if (t is null || t.Status == TransferStatus.Received) return false;
        t.Status = TransferStatus.Cancelled;
        t.UpdatedAt = DateTime.UtcNow;
        _repo.Update(t);
        await _repo.SaveChangesAsync();
        return true;
    }

    private static TransferListDto Map(VehicleTransfer t) => new()
    {
        Id = t.Id, VehicleId = t.VehicleId,
        RegistrationNumber = t.Vehicle?.RegistrationNumber ?? string.Empty,
        FromYardName = t.FromYard?.Name ?? string.Empty,
        ToYardName   = t.ToYard?.Name ?? string.Empty,
        Status = t.Status, Reason = t.Reason,
        CreatedAt = t.CreatedAt, ApprovedAt = t.ApprovedAt,
        DispatchedAt = t.DispatchedAt, ReceivedAt = t.ReceivedAt
    };
}
