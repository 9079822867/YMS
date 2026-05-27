using BCrypt.Net;
using YMS.Application.DTOs;
using YMS.Application.Interfaces;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;

namespace YMS.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;

    public AuthService(IUserRepository userRepository, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<LoginResponse?> LoginAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user is null || !user.IsActive)
            return null;

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return null;

        user.LastLogin = DateTime.UtcNow;
        user.UpdatedAt = DateTime.UtcNow;
        _userRepository.Update(user);
        await _userRepository.SaveChangesAsync();

        return new LoginResponse
        {
            Token = _jwtService.GenerateToken(user),
            FullName = user.FullName,
            Email = user.Email,
            Role = user.Role,
            UserId = user.Id
        };
    }

    public async Task<bool> RegisterAsync(RegisterRequest request)
    {
        var existing = await _userRepository.GetByEmailAsync(request.Email);
        if (existing is not null)
            return false;

        var user = new User
        {
            FullName = request.FullName,
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Role = request.Role
        };

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();
        return true;
    }
}
