using Moq;
using Xunit;
using YMS.Application.DTOs;
using YMS.Application.Services;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;

namespace YMS.Tests;

public class ProjectServiceTests
{
    private readonly Mock<IRepository<Project>> _projMock    = new();
    private readonly Mock<IRepository<Vehicle>> _vehicleMock = new();
    private readonly ProjectService _service;

    public ProjectServiceTests()
    {
        _service = new ProjectService(_projMock.Object, _vehicleMock.Object);
    }

    private static Project SampleProject(int id = 1) => new()
    {
        Id = id, ProjectName = "Repo Q1", Status = "Active", Priority = "High",
        StartDate = DateTime.UtcNow, ClientId = 1,
        Client = new Client { Id = 1, Name = "HDFC Bank" },
        Vehicles = new List<Vehicle>()
    };

    // ── Search ────────────────────────────────────────────────
    [Fact]
    public async Task Search_ReturnsPagedResult_OrderedByCreatedAtDesc()
    {
        var projects = new List<Project>
        {
            new() { Id=1, ProjectName="Alpha", Status="Active", Priority="High",   StartDate=DateTime.UtcNow, CreatedAt=DateTime.UtcNow.AddDays(-1), ClientId=1, Client=new Client{Name="HDFC"}, Vehicles=new List<Vehicle>() },
            new() { Id=2, ProjectName="Beta",  Status="Active", Priority="Medium", StartDate=DateTime.UtcNow, CreatedAt=DateTime.UtcNow,             ClientId=2, Client=new Client{Name="ICICI"}, Vehicles=new List<Vehicle>() },
        };
        _projMock.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Project, bool>>>())).ReturnsAsync(projects);

        var result = await _service.SearchAsync(new ProjectSearchRequest { Page = 1, PageSize = 25 });

        Assert.Equal(2, result.TotalCount);
        Assert.Equal("Beta", result.Items.First().ProjectName); // newest first
    }

    [Fact]
    public async Task Search_FiltersByStatus()
    {
        var projects = new List<Project>
        {
            new() { Id=1, ProjectName="A", Status="Active",    Priority="High", StartDate=DateTime.UtcNow, ClientId=1, Client=new Client{Name="X"}, Vehicles=new List<Vehicle>() },
            new() { Id=2, ProjectName="B", Status="Completed", Priority="Low",  StartDate=DateTime.UtcNow, ClientId=1, Client=new Client{Name="X"}, Vehicles=new List<Vehicle>() },
        };
        _projMock.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Project, bool>>>())).ReturnsAsync(projects);

        var result = await _service.SearchAsync(new ProjectSearchRequest { Status = "Active", Page = 1, PageSize = 25 });

        Assert.Equal(1, result.TotalCount);
        Assert.Equal("A", result.Items.First().ProjectName);
    }

    // ── GetById ──────────────────────────────────────────────
    [Fact]
    public async Task GetById_Existing_ReturnsDetail()
    {
        _projMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(SampleProject());
        var result = await _service.GetByIdAsync(1);
        Assert.NotNull(result);
        Assert.Equal("Repo Q1", result!.ProjectName);
        Assert.Equal("HDFC Bank", result.ClientName);
    }

    [Fact]
    public async Task GetById_NonExisting_ReturnsNull()
    {
        _projMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Project?)null);
        Assert.Null(await _service.GetByIdAsync(99));
    }

    // ── Create ───────────────────────────────────────────────
    [Fact]
    public async Task Create_ValidRequest_SavesAndReturnsDto()
    {
        _projMock.Setup(r => r.AddAsync(It.IsAny<Project>())).Returns(Task.CompletedTask);
        _projMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        var result = await _service.CreateAsync(new SaveProjectRequest
        {
            ProjectName = "New Project", ClientId = 2, Status = "Active",
            Priority = "High", StartDate = DateTime.UtcNow
        });

        Assert.Equal("New Project", result.ProjectName);
        _projMock.Verify(r => r.AddAsync(It.Is<Project>(p => p.ProjectName == "New Project")), Times.Once);
    }

    [Theory]
    [InlineData("Active")]
    [InlineData("On Hold")]
    [InlineData("Completed")]
    [InlineData("Cancelled")]
    public async Task Create_AllValidStatuses_Succeeds(string status)
    {
        _projMock.Setup(r => r.AddAsync(It.IsAny<Project>())).Returns(Task.CompletedTask);
        _projMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        var result = await _service.CreateAsync(new SaveProjectRequest
        {
            ProjectName = "P", ClientId = 1, Status = status, Priority = "Low", StartDate = DateTime.UtcNow
        });

        Assert.Equal(status, result.Status);
    }

    [Fact]
    public async Task Create_InvalidStatus_DefaultsToActive()
    {
        _projMock.Setup(r => r.AddAsync(It.IsAny<Project>())).Returns(Task.CompletedTask);
        _projMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        var result = await _service.CreateAsync(new SaveProjectRequest
        {
            ProjectName = "P", ClientId = 1, Status = "BadStatus", Priority = "High", StartDate = DateTime.UtcNow
        });

        Assert.Equal("Active", result.Status);
    }

    // ── Update ───────────────────────────────────────────────
    [Fact]
    public async Task Update_ExistingProject_ChangesFields()
    {
        var project = SampleProject();
        _projMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(project);
        _projMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        var (ok, err) = await _service.UpdateAsync(1, new SaveProjectRequest
        {
            ProjectName = "Updated Name", ClientId = 1, Status = "Completed",
            Priority = "Low", StartDate = DateTime.UtcNow
        });

        Assert.True(ok);
        Assert.Equal("Updated Name", project.ProjectName);
        Assert.Equal("Completed", project.Status);
        Assert.Equal("Low", project.Priority);
    }

    [Fact]
    public async Task Update_NonExisting_ReturnsError()
    {
        _projMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Project?)null);
        var (ok, err) = await _service.UpdateAsync(99, new SaveProjectRequest { ProjectName="X", ClientId=1, Status="Active", Priority="Low", StartDate=DateTime.UtcNow });
        Assert.False(ok);
        Assert.Contains("not found", err);
    }

    [Fact]
    public async Task Update_InvalidStatus_ReturnsError()
    {
        _projMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(SampleProject());
        var (ok, err) = await _service.UpdateAsync(1, new SaveProjectRequest { ProjectName="X", ClientId=1, Status="INVALID", Priority="High", StartDate=DateTime.UtcNow });
        Assert.False(ok);
        Assert.Contains("Invalid status", err);
    }

    // ── Delete ───────────────────────────────────────────────
    [Fact]
    public async Task Delete_ExistingProject_SoftDeletes()
    {
        var project = SampleProject();
        _projMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(project);
        _projMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        Assert.True(await _service.DeleteAsync(1));
        Assert.True(project.IsDeleted);
    }

    [Fact]
    public async Task Delete_NonExisting_ReturnsFalse()
    {
        _projMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Project?)null);
        Assert.False(await _service.DeleteAsync(99));
    }

    // ── AssignVehicle ────────────────────────────────────────
    [Fact]
    public async Task AssignVehicle_Valid_SetsProjectId()
    {
        var vehicle = new Vehicle { Id = 10, ProjectId = null };
        _projMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(SampleProject());
        _vehicleMock.Setup(r => r.GetByIdAsync(10)).ReturnsAsync(vehicle);
        _vehicleMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        var (ok, _) = await _service.AssignVehicleAsync(1, 10);

        Assert.True(ok);
        Assert.Equal(1, vehicle.ProjectId);
    }

    [Fact]
    public async Task AssignVehicle_AlreadyAssigned_ReturnsError()
    {
        var vehicle = new Vehicle { Id = 10, ProjectId = 1 };
        _projMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(SampleProject());
        _vehicleMock.Setup(r => r.GetByIdAsync(10)).ReturnsAsync(vehicle);

        var (ok, err) = await _service.AssignVehicleAsync(1, 10);

        Assert.False(ok);
        Assert.Contains("already assigned", err);
    }

    [Fact]
    public async Task RemoveVehicle_Valid_ClearsProjectId()
    {
        var vehicle = new Vehicle { Id = 5, ProjectId = 1 };
        _vehicleMock.Setup(r => r.GetByIdAsync(5)).ReturnsAsync(vehicle);
        _vehicleMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        Assert.True(await _service.RemoveVehicleAsync(1, 5));
        Assert.Null(vehicle.ProjectId);
    }
}
