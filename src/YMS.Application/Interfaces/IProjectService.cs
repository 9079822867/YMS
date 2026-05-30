using YMS.Application.DTOs;

namespace YMS.Application.Interfaces;

public interface IProjectService
{
    Task<PagedResult<ProjectListDto>> SearchAsync(ProjectSearchRequest request);
    Task<ProjectDetailDto?> GetByIdAsync(int id);
    Task<ProjectDetailDto> CreateAsync(SaveProjectRequest request);
    Task<(bool Success, string Error)> UpdateAsync(int id, SaveProjectRequest request);
    Task<bool> DeleteAsync(int id);
    Task<(bool Success, string Error)> AssignVehicleAsync(int projectId, int vehicleId);
    Task<bool> RemoveVehicleAsync(int projectId, int vehicleId);
}
