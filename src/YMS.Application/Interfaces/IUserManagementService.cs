using YMS.Application.DTOs;

namespace YMS.Application.Interfaces;

public interface IUserManagementService
{
    Task<IEnumerable<UserListDto>> GetAllAsync();
    Task<UserListDto?> GetByIdAsync(int id);
    Task<(bool Success, string Error)> CreateAsync(CreateUserRequest request);
    Task<(bool Success, string Error)> UpdateAsync(int id, UpdateUserRequest request);
    Task<bool> DeleteAsync(int id);
}
