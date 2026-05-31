using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YMS.Application.DTOs;
using YMS.Application.Interfaces;
using YMS.Domain.Entities;

namespace YMS.API.Controllers;

[ApiController]
[Route("api/inspections")]
[Authorize]
public class InspectionController : ControllerBase
{
    private readonly IInspectionService _service;
    public InspectionController(IInspectionService service) => _service = service;

    private int Uid => int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var i) ? i : 0;

    [HttpGet] public async Task<IActionResult> GetAll([FromQuery] string? status) => Ok(await _service.GetAllAsync(status));
    [HttpGet("statuses")] public IActionResult Statuses() => Ok(InspectionStatus.All);

    [HttpPost]
    [Authorize(Roles = "Admin,Operations")]
    public async Task<IActionResult> Create([FromBody] CreateInspectionRequest req)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var (ok, err, id) = await _service.CreateAsync(req, Uid);
        return ok ? Ok(new { message = "Inspection requested", id }) : BadRequest(new { message = err });
    }

    public record ScheduleBody(DateTime Date, string? Agency);

    [HttpPost("{id:int}/schedule")]
    [Authorize(Roles = "Admin,Operations")]
    public async Task<IActionResult> Schedule(int id, [FromBody] ScheduleBody body)
    {
        var (ok, err) = await _service.ScheduleAsync(id, body.Date, body.Agency);
        return ok ? NoContent() : BadRequest(new { message = err });
    }

    [HttpPost("{id:int}/complete")]
    [Authorize(Roles = "Admin,Operations")]
    public async Task<IActionResult> Complete(int id, [FromBody] CompleteInspectionRequest req)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var (ok, err) = await _service.CompleteAsync(id, req);
        return ok ? NoContent() : BadRequest(new { message = err });
    }

    [HttpPost("{id:int}/cancel")]
    [Authorize(Roles = "Admin,Operations")]
    public async Task<IActionResult> Cancel(int id) => await _service.CancelAsync(id) ? NoContent() : NotFound();
}
