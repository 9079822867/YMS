using Moq;
using Xunit;
using YMS.Application.DTOs;
using YMS.Application.Services;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;

namespace YMS.Tests;

public class MasterServiceTests
{
    private readonly Mock<IRepository<MasterItem>> _itemMock   = new();
    private readonly Mock<IRepository<Client>>     _clientMock = new();
    private readonly Mock<IRepository<Yard>>       _yardMock   = new();
    private readonly MasterService _service;

    public MasterServiceTests()
    {
        _service = new MasterService(_itemMock.Object, _clientMock.Object, _yardMock.Object);
    }

    // ── Generic items ─────────────────────────────────────────

    [Fact]
    public async Task GetItems_FiltersByCategory_OrderedBySortThenName()
    {
        _itemMock.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<MasterItem, bool>>>()))
            .ReturnsAsync(new List<MasterItem>
            {
                new() { Id=2, Category="State", Name="Maharashtra", SortOrder=1, IsActive=true },
                new() { Id=1, Category="State", Name="Delhi",       SortOrder=0, IsActive=true },
            });

        var result = (await _service.GetItemsAsync("State")).ToList();

        Assert.Equal(2, result.Count);
        Assert.Equal("Delhi", result[0].Name);       // SortOrder 0 first
        Assert.Equal("Maharashtra", result[1].Name);
    }

    [Theory]
    [InlineData("State")]
    [InlineData("VehicleType")]
    [InlineData("RunningStatus")]
    [InlineData("KeyStatus")]
    [InlineData("RcStatus")]
    [InlineData("FuelType")]
    [InlineData("TransmissionType")]
    public async Task SaveItem_Create_AllValidCategories_Succeeds(string category)
    {
        _itemMock.Setup(r => r.AddAsync(It.IsAny<MasterItem>())).Returns(Task.CompletedTask);
        _itemMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        var (ok, err) = await _service.SaveItemAsync(null,
            new SaveMasterItemRequest { Category = category, Name = "TestName", SortOrder = 1 });

        Assert.True(ok);
        Assert.Empty(err);
        _itemMock.Verify(r => r.AddAsync(It.Is<MasterItem>(m => m.Category == category)), Times.Once);
    }

    [Fact]
    public async Task SaveItem_Create_InvalidCategory_ReturnsError()
    {
        var (ok, err) = await _service.SaveItemAsync(null,
            new SaveMasterItemRequest { Category = "InvalidCat", Name = "X" });

        Assert.False(ok);
        Assert.Contains("Invalid category", err);
        _itemMock.Verify(r => r.AddAsync(It.IsAny<MasterItem>()), Times.Never);
    }

    [Fact]
    public async Task SaveItem_Update_ExistingItem_UpdatesFields()
    {
        var item = new MasterItem { Id = 5, Category = "State", Name = "Old", SortOrder = 0, IsActive = true };
        _itemMock.Setup(r => r.GetByIdAsync(5)).ReturnsAsync(item);
        _itemMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        var (ok, _) = await _service.SaveItemAsync(5,
            new SaveMasterItemRequest { Category = "State", Name = "Updated", SortOrder = 3, IsActive = false });

        Assert.True(ok);
        Assert.Equal("Updated", item.Name);
        Assert.Equal(3, item.SortOrder);
        Assert.False(item.IsActive);
    }

    [Fact]
    public async Task SaveItem_Update_NonExisting_ReturnsError()
    {
        _itemMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((MasterItem?)null);
        var (ok, err) = await _service.SaveItemAsync(99, new SaveMasterItemRequest { Category = "State", Name = "X" });
        Assert.False(ok);
        Assert.Contains("not found", err);
    }

    [Fact]
    public async Task DeleteItem_ExistingItem_SoftDeletes()
    {
        var item = new MasterItem { Id = 3, IsDeleted = false };
        _itemMock.Setup(r => r.GetByIdAsync(3)).ReturnsAsync(item);
        _itemMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        var ok = await _service.DeleteItemAsync(3);

        Assert.True(ok);
        Assert.True(item.IsDeleted);
    }

    // ── Clients ───────────────────────────────────────────────

    [Fact]
    public async Task GetClients_ReturnsActiveOrderedByName()
    {
        _clientMock.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Client, bool>>>()))
            .ReturnsAsync(new List<Client>
            {
                new() { Id=2, Name="ICICI Bank", IsActive=true },
                new() { Id=1, Name="HDFC Bank",  IsActive=true },
            });

        var result = (await _service.GetClientsAsync()).ToList();

        Assert.Equal(2, result.Count);
        Assert.Equal("HDFC Bank", result[0].Name);
    }

    [Fact]
    public async Task CreateClient_SavesAndReturnsDto()
    {
        _clientMock.Setup(r => r.AddAsync(It.IsAny<Client>())).Returns(Task.CompletedTask);
        _clientMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        var result = await _service.CreateClientAsync(new SaveClientRequest
        {
            Name = "Kotak Bank", ContactPerson = "Mgr", Phone = "9900000000", Email = "k@bank.com", IsActive = true
        });

        Assert.Equal("Kotak Bank", result.Name);
        _clientMock.Verify(r => r.AddAsync(It.Is<Client>(c => c.Name == "Kotak Bank")), Times.Once);
    }

    [Fact]
    public async Task UpdateClient_ExistingClient_UpdatesFields()
    {
        var client = new Client { Id = 1, Name = "Old", IsActive = true };
        _clientMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(client);
        _clientMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        var (ok, _) = await _service.UpdateClientAsync(1, new SaveClientRequest { Name = "New Bank", IsActive = false });

        Assert.True(ok);
        Assert.Equal("New Bank", client.Name);
        Assert.False(client.IsActive);
    }

    [Fact]
    public async Task DeleteClient_SoftDeletes()
    {
        var client = new Client { Id = 4, IsDeleted = false };
        _clientMock.Setup(r => r.GetByIdAsync(4)).ReturnsAsync(client);
        _clientMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        Assert.True(await _service.DeleteClientAsync(4));
        Assert.True(client.IsDeleted);
    }

    // ── Yards ─────────────────────────────────────────────────

    [Fact]
    public async Task CreateYard_SavesAndReturnsDto()
    {
        _yardMock.Setup(r => r.AddAsync(It.IsAny<Yard>())).Returns(Task.CompletedTask);
        _yardMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        var result = await _service.CreateYardAsync(new SaveYardRequest
        {
            Name = "Chennai Yard", City = "Chennai", State = "Tamil Nadu", IsActive = true
        });

        Assert.Equal("Chennai Yard", result.Name);
        Assert.Equal("Tamil Nadu", result.State);
    }

    [Fact]
    public async Task UpdateYard_NonExisting_ReturnsError()
    {
        _yardMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Yard?)null);
        var (ok, err) = await _service.UpdateYardAsync(99, new SaveYardRequest { Name = "X", City = "X", State = "X" });
        Assert.False(ok);
        Assert.Contains("not found", err);
    }

    [Fact]
    public async Task DeleteYard_SoftDeletes()
    {
        var yard = new Yard { Id = 2, IsDeleted = false };
        _yardMock.Setup(r => r.GetByIdAsync(2)).ReturnsAsync(yard);
        _yardMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        Assert.True(await _service.DeleteYardAsync(2));
        Assert.True(yard.IsDeleted);
    }
}
