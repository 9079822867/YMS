using Moq;
using Xunit;
using YMS.Application.DTOs;
using YMS.Application.Services;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;

namespace YMS.Tests;

public class TransferServiceTests
{
    private readonly Mock<ITransferRepository> _repo = new();
    private readonly Mock<IRepository<Vehicle>> _veh  = new();
    private readonly TransferService _service;

    public TransferServiceTests()
    {
        _service = new TransferService(_repo.Object, _veh.Object);
        _repo.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);
        _veh.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);
    }

    [Fact]
    public async Task Create_Valid_Succeeds()
    {
        _veh.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Vehicle { Id = 1, YardId = 1 });
        _repo.Setup(r => r.HasOpenAsync(1)).ReturnsAsync(false);
        _repo.Setup(r => r.AddAsync(It.IsAny<VehicleTransfer>())).Returns(Task.CompletedTask);

        var (ok, err, _) = await _service.CreateAsync(new CreateTransferRequest { VehicleId = 1, ToYardId = 2 }, 5);
        Assert.True(ok);
        _repo.Verify(r => r.AddAsync(It.Is<VehicleTransfer>(t => t.FromYardId == 1 && t.ToYardId == 2)), Times.Once);
    }

    [Fact]
    public async Task Create_SameYard_Fails()
    {
        _veh.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Vehicle { Id = 1, YardId = 2 });
        var (ok, err, _) = await _service.CreateAsync(new CreateTransferRequest { VehicleId = 1, ToYardId = 2 }, 5);
        Assert.False(ok);
        Assert.Contains("already in the destination", err);
    }

    [Fact]
    public async Task Create_OpenExists_Fails()
    {
        _veh.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Vehicle { Id = 1, YardId = 1 });
        _repo.Setup(r => r.HasOpenAsync(1)).ReturnsAsync(true);
        var (ok, err, _) = await _service.CreateAsync(new CreateTransferRequest { VehicleId = 1, ToYardId = 2 }, 5);
        Assert.False(ok);
        Assert.Contains("open transfer", err);
    }

    [Fact]
    public async Task FullWorkflow_Approve_Dispatch_Receive_MovesVehicle()
    {
        var t = new VehicleTransfer { Id = 1, VehicleId = 1, FromYardId = 1, ToYardId = 2, Status = TransferStatus.Requested };
        var v = new Vehicle { Id = 1, YardId = 1, RunningStatus = "Running" };
        _repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(t);
        _veh.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(v);

        Assert.True((await _service.ApproveAsync(1, true, null, 9)).Success);
        Assert.Equal(TransferStatus.Approved, t.Status);

        Assert.True((await _service.DispatchAsync(1)).Success);
        Assert.Equal(TransferStatus.Dispatched, t.Status);
        Assert.Equal("In Transit", v.RunningStatus);

        Assert.True((await _service.ReceiveAsync(1)).Success);
        Assert.Equal(TransferStatus.Received, t.Status);
        Assert.Equal(2, v.YardId);                 // vehicle moved
        Assert.Equal("Running", v.RunningStatus);
    }

    [Fact]
    public async Task Dispatch_NotApproved_Fails()
    {
        _repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new VehicleTransfer { Id = 1, Status = TransferStatus.Requested });
        var (ok, err) = await _service.DispatchAsync(1);
        Assert.False(ok);
        Assert.Contains("approved before dispatch", err);
    }

    [Fact]
    public async Task Reject_SetsRejected()
    {
        var t = new VehicleTransfer { Id = 1, Status = TransferStatus.Requested };
        _repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(t);
        await _service.ApproveAsync(1, false, "No capacity", 9);
        Assert.Equal(TransferStatus.Rejected, t.Status);
        Assert.Equal("No capacity", t.RejectionReason);
    }
}
