using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YMS.Application.Interfaces;

namespace YMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DashboardController : ControllerBase
{
    private readonly IInventoryService _inventoryService;

    public DashboardController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    [HttpGet("stats")]
    public async Task<IActionResult> GetStats()
    {
        var stats = await _inventoryService.GetDashboardStatsAsync();
        return Ok(stats);
    }

    [HttpGet("overview")]
    public async Task<IActionResult> GetOverview([FromServices] IDashboardService dashboard)
    {
        var overview = await dashboard.GetOverviewAsync();
        return Ok(overview);
    }
}
