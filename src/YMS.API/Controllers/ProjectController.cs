using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YMS.Application.DTOs;
using YMS.Application.Interfaces;
using YMS.Domain.Entities;

namespace YMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _service;

    public ProjectController(IProjectService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Search([FromQuery] ProjectSearchRequest request)
    {
        var result = await _service.SearchAsync(request);
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var project = await _service.GetByIdAsync(id);
        return project is null ? NotFound() : Ok(project);
    }

    [HttpGet("statuses")]
    public IActionResult GetStatuses() => Ok(ProjectStatus.All);

    [HttpGet("priorities")]
    public IActionResult GetPriorities() => Ok(ProjectPriority.All);

    [HttpPost]
    [Authorize(Roles = "Admin,Operations")]
    public async Task<IActionResult> Create([FromBody] SaveProjectRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var created = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin,Operations")]
    public async Task<IActionResult> Update(int id, [FromBody] SaveProjectRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var (ok, err) = await _service.UpdateAsync(id, request);
        if (!ok) return err == "Project not found" ? NotFound() : BadRequest(new { message = err });
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await _service.DeleteAsync(id);
        return ok ? NoContent() : NotFound();
    }

    [HttpPost("{projectId:int}/vehicles/{vehicleId:int}")]
    [Authorize(Roles = "Admin,Operations")]
    public async Task<IActionResult> AssignVehicle(int projectId, int vehicleId)
    {
        var (ok, err) = await _service.AssignVehicleAsync(projectId, vehicleId);
        if (!ok) return BadRequest(new { message = err });
        return Ok(new { message = "Vehicle assigned to project" });
    }

    [HttpDelete("{projectId:int}/vehicles/{vehicleId:int}")]
    [Authorize(Roles = "Admin,Operations")]
    public async Task<IActionResult> RemoveVehicle(int projectId, int vehicleId)
    {
        var ok = await _service.RemoveVehicleAsync(projectId, vehicleId);
        return ok ? NoContent() : NotFound();
    }
}
