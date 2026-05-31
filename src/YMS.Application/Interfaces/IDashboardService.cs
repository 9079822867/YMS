using YMS.Application.DTOs;

namespace YMS.Application.Interfaces;

public interface IDashboardService
{
    Task<DashboardOverviewDto> GetOverviewAsync();
}
