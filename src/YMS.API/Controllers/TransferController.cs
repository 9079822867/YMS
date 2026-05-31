using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YMS.Application.DTOs;
using YMS.Application.Interfaces;
using YMS.Domain.Entities;

namespace YMS.API.Controllers;

[ApiController]
[Route("api/transfers")]
[Authorize]
public class TransferController : ControllerBase
{
    private readonly ITransferService _service;
    public TransferController(ITransferService service) => _service = service;

    private int Uid => int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var i) ? i : 0;

    [HttpGet] public async Task<IActionResult> GetAll([FromQuery] string? status) => Ok(await _service.GetAllAsync(status));
    [HttpGet("statuses")] public IActionResult Statuses() => Ok(TransferStatus.All);
    [HttpGet("vehicle/{vehicleId:int}")] public async Task<IActionResult> History(int vehicleId) => Ok(await _service.GetHistoryAsync(vehicleId));

    [HttpPost]
    [Authorize(Roles = "Admin,Operations,Yard")]
    public async Task<IActionResult> Create([FromBody] CreateTransferRequest req)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var (ok, err, id) = await _service.CreateAsync(req, Uid);
        return ok ? Ok(new { message = "Transfer requested", id }) : BadRequest(new { message = err });
    }

    [HttpPost("{id:int}/approve")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Approve(int id, [FromBody] ApproveExitRequest req)
    {
        var (ok, err) = await _service.ApproveAsync(id, req.Approve, req.RejectionReason, Uid);
        return ok ? NoContent() : BadRequest(new { message = err });
    }

    [HttpPost("{id:int}/dispatch")]
    [Authorize(Roles = "Admin,Operations,Yard")]
    public async Task<IActionResult> Dispatch(int id)
    {
        var (ok, err) = await _service.DispatchAsync(id);
        return ok ? NoContent() : BadRequest(new { message = err });
    }

    [HttpPost("{id:int}/receive")]
    [Authorize(Roles = "Admin,Operations,Yard")]
    public async Task<IActionResult> Receive(int id)
    {
        var (ok, err) = await _service.ReceiveAsync(id);
        return ok ? NoContent() : BadRequest(new { message = err });
    }

    [HttpPost("{id:int}/cancel")]
    [Authorize(Roles = "Admin,Operations")]
    public async Task<IActionResult> Cancel(int id) => await _service.CancelAsync(id) ? NoContent() : NotFound();
}
