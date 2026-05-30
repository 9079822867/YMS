using YMS.Application.DTOs;

namespace YMS.Application.Interfaces;

public interface IInventoryService
{
    Task<PagedResult<VehicleListDto>> SearchAsync(VehicleSearchRequest request);
    Task<VehicleDetailDto?> GetByIdAsync(int id);
    Task<VehicleDetailDto> CreateAsync(CreateVehicleRequest request);
    Task<bool> UpdateStatusAsync(int id, UpdateVehicleStatusRequest request);
    Task<(bool Success, string Error)> UpdateVehicleAsync(int id, UpdateVehicleRequest request);
    Task<bool> DeleteAsync(int id);
    Task<DashboardResponse> GetDashboardStatsAsync();
}
