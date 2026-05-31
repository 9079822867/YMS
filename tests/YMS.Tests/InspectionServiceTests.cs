using Moq;
using Xunit;
using YMS.Application.DTOs;
using YMS.Application.Services;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;

namespace YMS.Tests;

public class InspectionServiceTests
{
    private readonly Mock<IInspectionRepository> _repo = new();
    private readonly Mock<IRepository<Vehicle>> _veh = new();
    private readonly InspectionService _service;

    public InspectionServiceTests()
    {
        _service = new InspectionService(_repo.Object, _veh.Object);
        _repo.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);
        _veh.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);
    }

    [Fact]
    public async Task Create_NoDate_StatusRequested_MarksVehiclePending()
    {
        var v = new Vehicle { Id = 1, RunningStatus = "Running" };
        _veh.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(v);
        _repo.Setup(r => r.AddAsync(It.IsAny<Inspection>())).Returns(Task.CompletedTask);

        var (ok, _, _) = await _service.CreateAsync(new CreateInspectionRequest { VehicleId = 1 }, 5);
        Assert.True(ok);
        Assert.Equal("Inspection Pending", v.RunningStatus);
        _repo.Verify(r => r.AddAsync(It.Is<Inspection>(i => i.Status == InspectionStatus.Requested)), Times.Once);
    }

    [Fact]
    public async Task Create_WithDate_StatusScheduled()
    {
        _veh.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Vehicle { Id = 1 });
        _repo.Setup(r => r.AddAsync(It.IsAny<Inspection>())).Returns(Task.CompletedTask);
        await _service.CreateAsync(new CreateInspectionRequest { VehicleId = 1, ScheduledDate = DateTime.UtcNow.AddDays(2) }, 5);
        _repo.Verify(r => r.AddAsync(It.Is<Inspection>(i => i.Status == InspectionStatus.Scheduled)), Times.Once);
    }

    [Fact]
    public async Task Complete_SetsValuationAndVehicleStatus()
    {
        var i = new Inspection { Id = 1, VehicleId = 1, Status = InspectionStatus.Scheduled };
        var v = new Vehicle { Id = 1, RunningStatus = "Inspection Pending" };
        _repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(i);
        _veh.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(v);

        var (ok, _) = await _service.CompleteAsync(1, new CompleteInspectionRequest { ValuationAmount = 250000 });
        Assert.True(ok);
        Assert.Equal(InspectionStatus.Completed, i.Status);
        Assert.Equal(250000, i.ValuationAmount);
        Assert.Equal("Valuation Complete", v.RunningStatus);
    }

    [Fact]
    public async Task Complete_ZeroValuation_Fails()
    {
        _repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Inspection { Id = 1, Status = InspectionStatus.Scheduled });
        var (ok, err) = await _service.CompleteAsync(1, new CompleteInspectionRequest { ValuationAmount = 0 });
        Assert.False(ok);
        Assert.Contains("greater than zero", err);
    }

    [Fact]
    public async Task Schedule_SetsDateAndStatus()
    {
        var i = new Inspection { Id = 1, Status = InspectionStatus.Requested };
        _repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(i);
        var date = DateTime.UtcNow.AddDays(3);
        await _service.ScheduleAsync(1, date, "ABC Valuers");
        Assert.Equal(InspectionStatus.Scheduled, i.Status);
        Assert.Equal("ABC Valuers", i.ValuationAgency);
    }
}
