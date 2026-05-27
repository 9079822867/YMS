using Moq;
using Xunit;
using YMS.Application.DTOs;
using YMS.Application.Interfaces;
using YMS.Application.Services;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;

namespace YMS.Tests;

public class AuthServiceTests
{
    private readonly Mock<IUserRepository> _userRepoMock = new();
    private readonly Mock<IJwtService> _jwtMock = new();
    private readonly IAuthService _service;

    public AuthServiceTests()
    {
        _service = new AuthService(_userRepoMock.Object, _jwtMock.Object);
    }

    [Fact]
    public async Task Login_WithValidCredentials_ReturnsToken()
    {
        var hash = BCrypt.Net.BCrypt.HashPassword("Admin@123");
        _userRepoMock.Setup(r => r.GetByEmailAsync("admin@yms.com"))
            .ReturnsAsync(new User { Id = 1, Email = "admin@yms.com", FullName = "Admin", Role = "Admin", PasswordHash = hash, IsActive = true });
        _jwtMock.Setup(j => j.GenerateToken(It.IsAny<User>())).Returns("test-token");
        _userRepoMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        var result = await _service.LoginAsync(new LoginRequest { Email = "admin@yms.com", Password = "Admin@123" });

        Assert.NotNull(result);
        Assert.Equal("test-token", result.Token);
        Assert.Equal("Admin", result.Role);
    }

    [Fact]
    public async Task Login_WithWrongPassword_ReturnsNull()
    {
        var hash = BCrypt.Net.BCrypt.HashPassword("Admin@123");
        _userRepoMock.Setup(r => r.GetByEmailAsync("admin@yms.com"))
            .ReturnsAsync(new User { Id = 1, Email = "admin@yms.com", PasswordHash = hash, IsActive = true });

        var result = await _service.LoginAsync(new LoginRequest { Email = "admin@yms.com", Password = "WrongPass" });

        Assert.Null(result);
    }

    [Fact]
    public async Task Login_WithNonexistentEmail_ReturnsNull()
    {
        _userRepoMock.Setup(r => r.GetByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync((User?)null);

        var result = await _service.LoginAsync(new LoginRequest { Email = "nobody@yms.com", Password = "pass" });

        Assert.Null(result);
    }

    [Fact]
    public async Task Login_WithInactiveUser_ReturnsNull()
    {
        var hash = BCrypt.Net.BCrypt.HashPassword("pass");
        _userRepoMock.Setup(r => r.GetByEmailAsync("user@yms.com"))
            .ReturnsAsync(new User { Id = 2, Email = "user@yms.com", PasswordHash = hash, IsActive = false });

        var result = await _service.LoginAsync(new LoginRequest { Email = "user@yms.com", Password = "pass" });

        Assert.Null(result);
    }

    [Fact]
    public async Task Register_WithNewEmail_ReturnsTrue()
    {
        _userRepoMock.Setup(r => r.GetByEmailAsync("new@yms.com")).ReturnsAsync((User?)null);
        _userRepoMock.Setup(r => r.AddAsync(It.IsAny<User>())).Returns(Task.CompletedTask);
        _userRepoMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        var result = await _service.RegisterAsync(new RegisterRequest
        {
            FullName = "New User",
            Email = "new@yms.com",
            Password = "Pass@123",
            Role = "Operations"
        });

        Assert.True(result);
        _userRepoMock.Verify(r => r.AddAsync(It.Is<User>(u => u.Email == "new@yms.com")), Times.Once);
    }

    [Fact]
    public async Task Register_WithExistingEmail_ReturnsFalse()
    {
        _userRepoMock.Setup(r => r.GetByEmailAsync("admin@yms.com"))
            .ReturnsAsync(new User { Id = 1, Email = "admin@yms.com" });

        var result = await _service.RegisterAsync(new RegisterRequest
        {
            FullName = "Dup",
            Email = "admin@yms.com",
            Password = "pass",
            Role = "Operations"
        });

        Assert.False(result);
        _userRepoMock.Verify(r => r.AddAsync(It.IsAny<User>()), Times.Never);
    }

    [Fact]
    public async Task Register_PasswordIsHashed()
    {
        User? savedUser = null;
        _userRepoMock.Setup(r => r.GetByEmailAsync(It.IsAny<string>())).ReturnsAsync((User?)null);
        _userRepoMock.Setup(r => r.AddAsync(It.IsAny<User>()))
            .Callback<User>(u => savedUser = u)
            .Returns(Task.CompletedTask);
        _userRepoMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        await _service.RegisterAsync(new RegisterRequest { FullName = "Test", Email = "t@t.com", Password = "PlainText", Role = "Operations" });

        Assert.NotNull(savedUser);
        Assert.NotEqual("PlainText", savedUser!.PasswordHash);
        Assert.True(BCrypt.Net.BCrypt.Verify("PlainText", savedUser.PasswordHash));
    }
}
