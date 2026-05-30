using Moq;
using Xunit;
using YMS.Application.DTOs;
using YMS.Application.Services;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;

namespace YMS.Tests;

public class UserManagementServiceTests
{
    private readonly Mock<IUserRepository> _repoMock = new();
    private readonly UserManagementService _service;

    public UserManagementServiceTests()
    {
        _service = new UserManagementService(_repoMock.Object);
    }

    // ── GetAll ──────────────────────────────────────────────────
    [Fact]
    public async Task GetAll_ReturnsAllUsers_OrderedByRoleThenName()
    {
        _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<User>
        {
            new() { Id = 1, FullName = "Zara Admin",  Email = "z@a.com", Role = "Admin",      IsActive = true },
            new() { Id = 2, FullName = "Alice Ops",   Email = "a@o.com", Role = "Operations", IsActive = true },
            new() { Id = 3, FullName = "Bob Yard",    Email = "b@y.com", Role = "Yard",       IsActive = false },
            new() { Id = 4, FullName = "Carol Client",Email = "c@c.com", Role = "Client",     IsActive = true },
        });

        var result = (await _service.GetAllAsync()).ToList();

        Assert.Equal(4, result.Count);
        Assert.Equal("Admin", result[0].Role);
        Assert.Equal("Client", result[1].Role);
    }

    // ── GetById ─────────────────────────────────────────────────
    [Fact]
    public async Task GetById_ExistingUser_ReturnsDto()
    {
        _repoMock.Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(new User { Id = 1, FullName = "Admin", Email = "a@yms.com", Role = "Admin", IsActive = true });

        var result = await _service.GetByIdAsync(1);

        Assert.NotNull(result);
        Assert.Equal("Admin", result!.Role);
    }

    [Fact]
    public async Task GetById_NonExisting_ReturnsNull()
    {
        _repoMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((User?)null);
        Assert.Null(await _service.GetByIdAsync(99));
    }

    // ── Create ──────────────────────────────────────────────────
    [Theory]
    [InlineData("Admin")]
    [InlineData("Operations")]
    [InlineData("Yard")]
    [InlineData("Client")]
    public async Task Create_AllValidRoles_Succeeds(string role)
    {
        _repoMock.Setup(r => r.GetByEmailAsync(It.IsAny<string>())).ReturnsAsync((User?)null);
        _repoMock.Setup(r => r.AddAsync(It.IsAny<User>())).Returns(Task.CompletedTask);
        _repoMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        var (success, error) = await _service.CreateAsync(new CreateUserRequest
        {
            FullName = "Test User", Email = "test@yms.com", Password = "pass123", Role = role
        });

        Assert.True(success);
        Assert.Empty(error);
    }

    [Fact]
    public async Task Create_InvalidRole_ReturnsError()
    {
        var (success, error) = await _service.CreateAsync(new CreateUserRequest
        {
            FullName = "X", Email = "x@x.com", Password = "pass", Role = "SuperUser"
        });

        Assert.False(success);
        Assert.Contains("Invalid role", error);
        _repoMock.Verify(r => r.AddAsync(It.IsAny<User>()), Times.Never);
    }

    [Fact]
    public async Task Create_DuplicateEmail_ReturnsError()
    {
        _repoMock.Setup(r => r.GetByEmailAsync("dup@yms.com"))
            .ReturnsAsync(new User { Id = 1, Email = "dup@yms.com" });

        var (success, error) = await _service.CreateAsync(new CreateUserRequest
        {
            FullName = "Dup", Email = "dup@yms.com", Password = "pass", Role = "Operations"
        });

        Assert.False(success);
        Assert.Contains("already registered", error);
    }

    [Fact]
    public async Task Create_PasswordIsHashed()
    {
        User? saved = null;
        _repoMock.Setup(r => r.GetByEmailAsync(It.IsAny<string>())).ReturnsAsync((User?)null);
        _repoMock.Setup(r => r.AddAsync(It.IsAny<User>())).Callback<User>(u => saved = u).Returns(Task.CompletedTask);
        _repoMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        await _service.CreateAsync(new CreateUserRequest { FullName = "T", Email = "t@t.com", Password = "MySecret", Role = "Yard" });

        Assert.NotNull(saved);
        Assert.NotEqual("MySecret", saved!.PasswordHash);
        Assert.True(BCrypt.Net.BCrypt.Verify("MySecret", saved.PasswordHash));
    }

    // ── Update ──────────────────────────────────────────────────
    [Fact]
    public async Task Update_ValidRequest_ChangesFields()
    {
        var user = new User { Id = 5, FullName = "Old Name", Email = "old@yms.com", Role = "Operations", IsActive = true };
        _repoMock.Setup(r => r.GetByIdAsync(5)).ReturnsAsync(user);
        _repoMock.Setup(r => r.GetByEmailAsync("new@yms.com")).ReturnsAsync((User?)null);
        _repoMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        var (success, error) = await _service.UpdateAsync(5, new UpdateUserRequest
        {
            FullName = "New Name", Email = "new@yms.com", Role = "Yard", IsActive = false
        });

        Assert.True(success);
        Assert.Equal("New Name", user.FullName);
        Assert.Equal("new@yms.com", user.Email);
        Assert.Equal("Yard", user.Role);
        Assert.False(user.IsActive);
    }

    [Fact]
    public async Task Update_WithNewPassword_HashesIt()
    {
        var user = new User { Id = 3, FullName = "U", Email = "u@u.com", Role = "Client", IsActive = true, PasswordHash = "oldhash" };
        _repoMock.Setup(r => r.GetByIdAsync(3)).ReturnsAsync(user);
        _repoMock.Setup(r => r.GetByEmailAsync(It.IsAny<string>())).ReturnsAsync((User?)null);
        _repoMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        await _service.UpdateAsync(3, new UpdateUserRequest { FullName = "U", Email = "u@u.com", Role = "Client", IsActive = true, Password = "NewPass!" });

        Assert.NotEqual("oldhash", user.PasswordHash);
        Assert.True(BCrypt.Net.BCrypt.Verify("NewPass!", user.PasswordHash));
    }

    [Fact]
    public async Task Update_WithNullPassword_KeepsOldHash()
    {
        var user = new User { Id = 4, FullName = "U", Email = "u@u.com", Role = "Admin", IsActive = true, PasswordHash = "keptHash" };
        _repoMock.Setup(r => r.GetByIdAsync(4)).ReturnsAsync(user);
        _repoMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        await _service.UpdateAsync(4, new UpdateUserRequest { FullName = "U", Email = "u@u.com", Role = "Admin", IsActive = true, Password = null });

        Assert.Equal("keptHash", user.PasswordHash);
    }

    [Fact]
    public async Task Update_NonExistingUser_ReturnsError()
    {
        _repoMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((User?)null);
        var (success, error) = await _service.UpdateAsync(99, new UpdateUserRequest { FullName = "X", Email = "x@x.com", Role = "Admin", IsActive = true });
        Assert.False(success);
        Assert.Contains("not found", error);
    }

    [Fact]
    public async Task Update_EmailConflict_ReturnsError()
    {
        _repoMock.Setup(r => r.GetByIdAsync(2)).ReturnsAsync(new User { Id = 2, Email = "me@yms.com", Role = "Operations" });
        _repoMock.Setup(r => r.GetByEmailAsync("taken@yms.com")).ReturnsAsync(new User { Id = 9, Email = "taken@yms.com" });

        var (success, error) = await _service.UpdateAsync(2, new UpdateUserRequest { FullName = "X", Email = "taken@yms.com", Role = "Operations", IsActive = true });

        Assert.False(success);
        Assert.Contains("already used", error);
    }

    // ── Delete ──────────────────────────────────────────────────
    [Fact]
    public async Task Delete_ExistingUser_SoftDeletesAndReturnsTrue()
    {
        var user = new User { Id = 6, IsDeleted = false };
        _repoMock.Setup(r => r.GetByIdAsync(6)).ReturnsAsync(user);
        _repoMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        var result = await _service.DeleteAsync(6);

        Assert.True(result);
        Assert.True(user.IsDeleted);
        _repoMock.Verify(r => r.Update(user), Times.Once);
    }

    [Fact]
    public async Task Delete_NonExistingUser_ReturnsFalse()
    {
        _repoMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((User?)null);
        Assert.False(await _service.DeleteAsync(99));
    }
}
