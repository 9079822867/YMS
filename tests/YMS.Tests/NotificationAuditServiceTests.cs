using System.Linq.Expressions;
using Moq;
using Xunit;
using YMS.Application.Services;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;

namespace YMS.Tests;

public class NotificationServiceTests
{
    private readonly Mock<IRepository<Notification>> _repo = new();
    private readonly NotificationService _service;

    public NotificationServiceTests()
    {
        _service = new NotificationService(_repo.Object);
        _repo.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);
    }

    [Fact]
    public async Task Create_AddsNotification()
    {
        _repo.Setup(r => r.AddAsync(It.IsAny<Notification>())).Returns(Task.CompletedTask);
        await _service.CreateAsync(3, "Title", "Body", "Alert", "/inventory");
        _repo.Verify(r => r.AddAsync(It.Is<Notification>(n =>
            n.UserId == 3 && n.Title == "Title" && n.Type == "Alert" && n.Link == "/inventory")), Times.Once);
    }

    [Fact]
    public async Task GetUnreadCount_CountsUnread()
    {
        _repo.Setup(r => r.FindAsync(It.IsAny<Expression<Func<Notification, bool>>>()))
            .ReturnsAsync(new List<Notification> { new(), new(), new() });
        Assert.Equal(3, await _service.GetUnreadCountAsync(1));
    }

    [Fact]
    public async Task MarkRead_SetsIsRead()
    {
        var n = new Notification { Id = 1, IsRead = false };
        _repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(n);
        Assert.True(await _service.MarkReadAsync(1));
        Assert.True(n.IsRead);
    }

    [Fact]
    public async Task GetForUser_OrdersAndMaps()
    {
        _repo.Setup(r => r.FindAsync(It.IsAny<Expression<Func<Notification, bool>>>()))
            .ReturnsAsync(new List<Notification>
            {
                new() { Id = 1, Title = "Old", CreatedAt = DateTime.UtcNow.AddHours(-2) },
                new() { Id = 2, Title = "New", CreatedAt = DateTime.UtcNow },
            });
        var result = (await _service.GetForUserAsync(1, false)).ToList();
        Assert.Equal("New", result[0].Title);   // newest first
    }
}

public class AuditServiceTests
{
    private readonly Mock<IRepository<AuditLog>> _repo = new();
    private readonly AuditService _service;

    public AuditServiceTests()
    {
        _service = new AuditService(_repo.Object);
        _repo.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);
    }

    [Fact]
    public async Task Log_AddsAuditEntry()
    {
        _repo.Setup(r => r.AddAsync(It.IsAny<AuditLog>())).Returns(Task.CompletedTask);
        await _service.LogAsync(7, "Created Vehicle", "Vehicle", 42, "reg MH01", "127.0.0.1");
        _repo.Verify(r => r.AddAsync(It.Is<AuditLog>(a =>
            a.UserId == 7 && a.Action == "Created Vehicle" && a.EntityType == "Vehicle" && a.EntityId == 42)), Times.Once);
    }

    [Fact]
    public async Task GetRecent_FiltersByEntityType_OrderedDesc()
    {
        _repo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<AuditLog>
        {
            new() { Id = 1, EntityType = "Vehicle", Timestamp = DateTime.UtcNow.AddHours(-1) },
            new() { Id = 2, EntityType = "User",    Timestamp = DateTime.UtcNow },
            new() { Id = 3, EntityType = "Vehicle", Timestamp = DateTime.UtcNow },
        });
        var result = (await _service.GetRecentAsync(10, "Vehicle")).ToList();
        Assert.Equal(2, result.Count);
        Assert.Equal(3, result[0].Id);   // newest Vehicle first
    }
}
