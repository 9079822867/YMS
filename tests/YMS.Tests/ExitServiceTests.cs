using Moq;
using Xunit;
using YMS.Application.DTOs;
using YMS.Application.Services;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;

namespace YMS.Tests;

public class ExitServiceTests
{
    private readonly Mock<IExitRepository>      _exitMock    = new();
    private readonly Mock<IRepository<Vehicle>> _vehicleMock = new();
    private readonly ExitService _service;

    public ExitServiceTests()
    {
        _service = new ExitService(_exitMock.Object, _vehicleMock.Object);
        _exitMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);
        _vehicleMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);
    }

    private static Vehicle SampleVehicle(int id = 1, DateTime? exit = null) => new()
    {
        Id = id, RegistrationNumber = "MH01AB1234", ChassisNumber = "CH1",
        RunningStatus = "Running", ExitDate = exit
    };

    // ── Create ───────────────────────────────────────────────
    [Fact]
    public async Task Create_ValidRequest_Succeeds()
    {
        _vehicleMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(SampleVehicle());
        _exitMock.Setup(r => r.HasOpenRequestAsync(1)).ReturnsAsync(false);
        _exitMock.Setup(r => r.AddAsync(It.IsAny<VehicleExitRequest>())).Returns(Task.CompletedTask);

        var (ok, err, id) = await _service.CreateAsync(new CreateExitRequest
        {
            VehicleId = 1, ExitReason = "Auction Sale",
            ReceiverName = "Buyer A", ReceiverContact = "9000000000"
        }, requestedBy: 5);

        Assert.True(ok);
        Assert.Empty(err);
        _exitMock.Verify(r => r.AddAsync(It.Is<VehicleExitRequest>(
            e => e.VehicleId == 1 && e.Status == ExitStatus.Pending && e.RequestedBy == 5)), Times.Once);
    }

    [Fact]
    public async Task Create_InvalidReason_Fails()
    {
        var (ok, err, _) = await _service.CreateAsync(new CreateExitRequest
        {
            VehicleId = 1, ExitReason = "Teleport", ReceiverName = "X", ReceiverContact = "1"
        }, 1);

        Assert.False(ok);
        Assert.Contains("Invalid exit reason", err);
    }

    [Fact]
    public async Task Create_VehicleNotFound_Fails()
    {
        _vehicleMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Vehicle?)null);
        var (ok, err, _) = await _service.CreateAsync(new CreateExitRequest
        {
            VehicleId = 99, ExitReason = "Auction Sale", ReceiverName = "X", ReceiverContact = "1"
        }, 1);
        Assert.False(ok);
        Assert.Contains("Vehicle not found", err);
    }

    [Fact]
    public async Task Create_AlreadyExited_Fails()
    {
        _vehicleMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(SampleVehicle(1, DateTime.UtcNow));
        var (ok, err, _) = await _service.CreateAsync(new CreateExitRequest
        {
            VehicleId = 1, ExitReason = "Auction Sale", ReceiverName = "X", ReceiverContact = "1"
        }, 1);
        Assert.False(ok);
        Assert.Contains("already exited", err);
    }

    [Fact]
    public async Task Create_DuplicateOpenRequest_Fails()
    {
        _vehicleMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(SampleVehicle());
        _exitMock.Setup(r => r.HasOpenRequestAsync(1)).ReturnsAsync(true);
        var (ok, err, _) = await _service.CreateAsync(new CreateExitRequest
        {
            VehicleId = 1, ExitReason = "Auction Sale", ReceiverName = "X", ReceiverContact = "1"
        }, 1);
        Assert.False(ok);
        Assert.Contains("already open", err);
    }

    // ── Approve ──────────────────────────────────────────────
    [Fact]
    public async Task Approve_PendingRequest_GeneratesOtpAndGatePass()
    {
        var e = new VehicleExitRequest { Id = 1, VehicleId = 1, Status = ExitStatus.Pending, ExitReason = "Auction Sale" };
        _exitMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(e);

        var (ok, err, otp) = await _service.ApproveAsync(1, new ApproveExitRequest { Approve = true }, approverId: 9);

        Assert.True(ok);
        Assert.NotNull(otp);
        Assert.Matches(@"^\d{6}$", otp!.Otp);                  // 6-digit OTP
        Assert.StartsWith("GP-", otp.GatePassCode);            // gate pass issued
        Assert.Equal(ExitStatus.Approved, e.Status);
        Assert.Equal(9, e.ApprovedBy);
        Assert.NotNull(e.OtpHash);
        Assert.True(e.OtpExpiry > DateTime.UtcNow);
    }

    [Fact]
    public async Task Approve_Reject_SetsRejectedStatus_NoOtp()
    {
        var e = new VehicleExitRequest { Id = 1, Status = ExitStatus.Pending };
        _exitMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(e);

        var (ok, _, otp) = await _service.ApproveAsync(1,
            new ApproveExitRequest { Approve = false, RejectionReason = "Docs incomplete" }, 9);

        Assert.True(ok);
        Assert.Null(otp);
        Assert.Equal(ExitStatus.Rejected, e.Status);
        Assert.Equal("Docs incomplete", e.RejectionReason);
        Assert.Null(e.OtpHash);
    }

    [Fact]
    public async Task Approve_NonPending_Fails()
    {
        var e = new VehicleExitRequest { Id = 1, Status = ExitStatus.Completed };
        _exitMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(e);
        var (ok, err, _) = await _service.ApproveAsync(1, new ApproveExitRequest { Approve = true }, 9);
        Assert.False(ok);
        Assert.Contains("pending", err);
    }

    // ── Verify OTP ───────────────────────────────────────────
    [Fact]
    public async Task VerifyOtp_CorrectOtp_CompletesExitAndUpdatesVehicle()
    {
        // Approve first to capture the real OTP
        var e = new VehicleExitRequest { Id = 1, VehicleId = 1, Status = ExitStatus.Pending, ExitReason = "Auction Sale" };
        _exitMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(e);
        var vehicle = SampleVehicle();
        _vehicleMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(vehicle);

        var (_, _, otp) = await _service.ApproveAsync(1, new ApproveExitRequest { Approve = true }, 9);

        var (ok, err) = await _service.VerifyOtpAsync(1, otp!.Otp);

        Assert.True(ok);
        Assert.Equal(ExitStatus.Completed, e.Status);
        Assert.NotNull(e.ExitedAt);
        Assert.Null(e.OtpHash);                       // single-use burned
        Assert.NotNull(vehicle.ExitDate);             // vehicle marked exited
        Assert.Equal("Sold", vehicle.RunningStatus);  // Auction Sale → Sold
    }

    [Fact]
    public async Task VerifyOtp_WrongOtp_IncrementsAttempts_Fails()
    {
        var e = new VehicleExitRequest { Id = 1, VehicleId = 1, Status = ExitStatus.Pending, ExitReason = "Borrower Release" };
        _exitMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(e);
        await _service.ApproveAsync(1, new ApproveExitRequest { Approve = true }, 9);

        var (ok, err) = await _service.VerifyOtpAsync(1, "000000");

        Assert.False(ok);
        Assert.Contains("Incorrect OTP", err);
        Assert.Equal(1, e.OtpAttempts);
        Assert.Equal(ExitStatus.Approved, e.Status);   // still open
    }

    [Fact]
    public async Task VerifyOtp_Expired_Fails()
    {
        var e = new VehicleExitRequest
        {
            Id = 1, Status = ExitStatus.Approved,
            OtpHash = "whatever", OtpExpiry = DateTime.UtcNow.AddMinutes(-1)
        };
        _exitMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(e);

        var (ok, err) = await _service.VerifyOtpAsync(1, "123456");

        Assert.False(ok);
        Assert.Contains("expired", err);
    }

    [Fact]
    public async Task VerifyOtp_NotApprovedState_Fails()
    {
        var e = new VehicleExitRequest { Id = 1, Status = ExitStatus.Pending };
        _exitMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(e);
        var (ok, err) = await _service.VerifyOtpAsync(1, "123456");
        Assert.False(ok);
        Assert.Contains("not in an OTP-verifiable state", err);
    }

    // ── Regenerate ───────────────────────────────────────────
    [Fact]
    public async Task RegenerateOtp_ApprovedRequest_IssuesNewOtp()
    {
        var e = new VehicleExitRequest { Id = 1, Status = ExitStatus.Approved, GatePassCode = "GP-1", OtpAttempts = 3 };
        _exitMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(e);

        var (ok, _, otp) = await _service.RegenerateOtpAsync(1);

        Assert.True(ok);
        Assert.NotNull(otp);
        Assert.Matches(@"^\d{6}$", otp!.Otp);
        Assert.Equal(0, e.OtpAttempts);                 // reset
        Assert.True(e.OtpExpiry > DateTime.UtcNow);
    }

    // ── Cancel ───────────────────────────────────────────────
    [Fact]
    public async Task Cancel_OpenRequest_Succeeds()
    {
        var e = new VehicleExitRequest { Id = 1, Status = ExitStatus.Approved, OtpHash = "x" };
        _exitMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(e);

        Assert.True(await _service.CancelAsync(1));
        Assert.Equal(ExitStatus.Cancelled, e.Status);
        Assert.Null(e.OtpHash);
    }

    [Fact]
    public async Task Cancel_CompletedRequest_Fails()
    {
        var e = new VehicleExitRequest { Id = 1, Status = ExitStatus.Completed };
        _exitMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(e);
        Assert.False(await _service.CancelAsync(1));
    }
}
