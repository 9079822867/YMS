using Moq;
using Xunit;
using YMS.Application.DTOs;
using YMS.Application.Services;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;

namespace YMS.Tests;

public class InventoryServiceTests
{
    private readonly Mock<IInventoryRepository> _repoMock = new();
    private readonly InventoryService _service;

    public InventoryServiceTests()
    {
        _service = new InventoryService(_repoMock.Object);
    }

    [Fact]
    public async Task Search_ReturnsPagedResult()
    {
        var vehicles = new List<Vehicle>
        {
            new() { Id = 1, LoanNumber = "LN001", RegistrationNumber = "MH01AB1234",
                    ChassisNumber = "CH001", EngineNumber = "EN001", VehicleType = "Car",
                    RunningStatus = "Running", KeyStatus = "Yes", RcStatus = "Submitted",
                    ParkingCharges = 450, EntryDate = DateTime.UtcNow,
                    Client = new Client { Name = "HDFC Bank" },
                    Yard = new Yard { Name = "Mumbai Yard", City = "Mumbai", State = "Maharashtra" },
                    Reports = new List<Report>() }
        };

        _repoMock.Setup(r => r.SearchAsync(
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime?>(), It.IsAny<DateTime?>(),
                It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync((vehicles, 1));

        var result = await _service.SearchAsync(new VehicleSearchRequest { Page = 1, PageSize = 25 });

        Assert.Equal(1, result.TotalCount);
        Assert.Single(result.Items);
        Assert.Equal("HDFC Bank", result.Items.First().ClientName);
    }

    [Fact]
    public async Task GetById_ExistingId_ReturnsVehicleDetail()
    {
        var vehicle = new Vehicle
        {
            Id = 5, LoanNumber = "LN005", RegistrationNumber = "RJ14CD5678",
            ChassisNumber = "CH005", EngineNumber = "EN005", VehicleType = "Bike",
            RunningStatus = "Red/Idle", KeyStatus = "No", RcStatus = "Pending",
            ParkingCharges = 300, EntryDate = DateTime.UtcNow,
            Client = new Client { Name = "Axis Bank" },
            Yard = new Yard { Name = "Jaipur Yard", City = "Jaipur", State = "Rajasthan" },
            Reports = new List<Report>()
        };

        _repoMock.Setup(r => r.GetByIdAsync(5)).ReturnsAsync(vehicle);

        var result = await _service.GetByIdAsync(5);

        Assert.NotNull(result);
        Assert.Equal(5, result!.Id);
        Assert.Equal("Axis Bank", result.ClientName);
        Assert.Equal("Red/Idle", result.RunningStatus);
    }

    [Fact]
    public async Task GetById_NonExistingId_ReturnsNull()
    {
        _repoMock.Setup(r => r.GetByIdAsync(999)).ReturnsAsync((Vehicle?)null);

        var result = await _service.GetByIdAsync(999);

        Assert.Null(result);
    }

    [Fact]
    public async Task Create_ValidRequest_ReturnsCreatedVehicle()
    {
        _repoMock.Setup(r => r.AddAsync(It.IsAny<Vehicle>())).Returns(Task.CompletedTask);
        _repoMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        var request = new CreateVehicleRequest
        {
            ClientId = 1, YardId = 1,
            LoanNumber = "LN010", RegistrationNumber = "MH02EF3456",
            ChassisNumber = "CH010", EngineNumber = "EN010",
            VehicleType = "Car", RunningStatus = "Running",
            KeyStatus = "Yes", RcStatus = "Pending",
            DailyParkingRate = 450
        };

        var result = await _service.CreateAsync(request);

        Assert.Equal("LN010", result.LoanNumber);
        Assert.Equal("Running", result.RunningStatus);
        _repoMock.Verify(r => r.AddAsync(It.IsAny<Vehicle>()), Times.Once);
        _repoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task UpdateStatus_ExistingId_ReturnsTrue()
    {
        var vehicle = new Vehicle
        {
            Id = 3, RunningStatus = "Running", KeyStatus = "Yes", RcStatus = "Pending",
            Client = new Client { Name = "Test" }, Yard = new Yard { Name = "Y", City = "C", State = "S" },
            Reports = new List<Report>()
        };

        _repoMock.Setup(r => r.GetByIdAsync(3)).ReturnsAsync(vehicle);
        _repoMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        var result = await _service.UpdateStatusAsync(3, new UpdateVehicleStatusRequest
        {
            RunningStatus = "Red/Idle",
            RcStatus = "Submitted"
        });

        Assert.True(result);
        Assert.Equal("Red/Idle", vehicle.RunningStatus);
        Assert.Equal("Submitted", vehicle.RcStatus);
        Assert.Equal("Yes", vehicle.KeyStatus);
    }

    [Fact]
    public async Task UpdateStatus_NonExistingId_ReturnsFalse()
    {
        _repoMock.Setup(r => r.GetByIdAsync(999)).ReturnsAsync((Vehicle?)null);

        var result = await _service.UpdateStatusAsync(999, new UpdateVehicleStatusRequest { RunningStatus = "Running" });

        Assert.False(result);
    }

    [Fact]
    public async Task Delete_ExistingId_SoftDeletesAndReturnsTrue()
    {
        var vehicle = new Vehicle
        {
            Id = 7, IsDeleted = false,
            Client = new Client { Name = "Test" }, Yard = new Yard { Name = "Y", City = "C", State = "S" },
            Reports = new List<Report>()
        };
        _repoMock.Setup(r => r.GetByIdAsync(7)).ReturnsAsync(vehicle);
        _repoMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        var result = await _service.DeleteAsync(7);

        Assert.True(result);
        Assert.True(vehicle.IsDeleted);
    }

    [Fact]
    public async Task GetDashboardStats_ReturnsMappedResponse()
    {
        _repoMock.Setup(r => r.GetDashboardStatsAsync()).ReturnsAsync(new DashboardStats
        {
            TotalVehicles = 1245,
            RunningVehicles = 845,
            IdleVehicles = 210,
            PendingRc = 190,
            SubmittedReports = 50,
            TotalParkingCharges = 560250,
            ActiveYards = 15
        });

        var result = await _service.GetDashboardStatsAsync();

        Assert.Equal(1245, result.TotalVehicles);
        Assert.Equal(845, result.RunningVehicles);
        Assert.Equal(210, result.IdleVehicles);
        Assert.Equal(190, result.PendingRc);
        Assert.Equal(15, result.ActiveYards);
    }
}
