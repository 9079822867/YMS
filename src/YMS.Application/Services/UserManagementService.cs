using YMS.Application.DTOs;
using YMS.Application.Interfaces;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;

namespace YMS.Application.Services;

public class UserManagementService : IUserManagementService
{
    private readonly IUserRepository _userRepository;

    public static readonly string[] ValidRoles = { "Admin", "Operations", "Yard", "Client" };

    public UserManagementService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserListDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Select(MapToDto).OrderBy(u => u.Role).ThenBy(u => u.FullName);
    }

    public async Task<UserListDto?> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return user is null ? null : MapToDto(user);
    }

    public async Task<(bool Success, string Error)> CreateAsync(CreateUserRequest request)
    {
        if (!ValidRoles.Contains(request.Role))
            return (false, $"Invalid role. Valid roles: {string.Join(", ", ValidRoles)}");

        var existing = await _userRepository.GetByEmailAsync(request.Email);
        if (existing is not null)
            return (false, "Email is already registered");

        var user = new User
        {
            FullName = request.FullName.Trim(),
            Email = request.Email.Trim().ToLower(),
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Role = request.Role,
            IsActive = true
        };

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();
        return (true, string.Empty);
    }

    public async Task<(bool Success, string Error)> UpdateAsync(int id, UpdateUserRequest request)
    {
        if (!ValidRoles.Contains(request.Role))
            return (false, $"Invalid role. Valid roles: {string.Join(", ", ValidRoles)}");

        var user = await _userRepository.GetByIdAsync(id);
        if (user is null)
            return (false, "User not found");

        var normalizedEmail = request.Email.Trim().ToLower();
        if (!string.Equals(user.Email, normalizedEmail, StringComparison.OrdinalIgnoreCase))
        {
            var conflict = await _userRepository.GetByEmailAsync(normalizedEmail);
            if (conflict is not null)
                return (false, "Email is already used by another account");
        }

        user.FullName = request.FullName.Trim();
        user.Email = normalizedEmail;
        user.Role = request.Role;
        user.IsActive = request.IsActive;
        user.UpdatedAt = DateTime.UtcNow;

        if (!string.IsNullOrWhiteSpace(request.Password))
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        _userRepository.Update(user);
        await _userRepository.SaveChangesAsync();
        return (true, string.Empty);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user is null) return false;

        user.IsDeleted = true;
        user.UpdatedAt = DateTime.UtcNow;
        _userRepository.Update(user);
        await _userRepository.SaveChangesAsync();
        return true;
    }

    private static UserListDto MapToDto(User u) => new()
    {
        Id = u.Id,
        FullName = u.FullName,
        Email = u.Email,
        Role = u.Role,
        IsActive = u.IsActive,
        LastLogin = u.LastLogin,
        CreatedAt = u.CreatedAt
    };
}
