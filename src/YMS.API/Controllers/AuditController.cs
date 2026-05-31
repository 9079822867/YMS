using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YMS.Application.Interfaces;

namespace YMS.API.Controllers;

[ApiController]
[Route("api/audit")]
[Authorize(Roles = "Admin")]
public class AuditController : ControllerBase
{
    private readonly IAuditService _service;
    public AuditController(IAuditService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetRecent([FromQuery] int take = 100, [FromQuery] string? entityType = null)
        => Ok(await _service.GetRecentAsync(take, entityType));
}
