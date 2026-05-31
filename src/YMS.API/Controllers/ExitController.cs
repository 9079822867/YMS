using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YMS.Application.DTOs;
using YMS.Application.Interfaces;
using YMS.Domain.Entities;

namespace YMS.API.Controllers;

[ApiController]
[Route("api/exits")]
[Authorize]
public class ExitController : ControllerBase
{
    private readonly IExitService _service;

    public ExitController(IExitService service)
    {
        _service = service;
    }

    private int CurrentUserId =>
        int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var id) ? id : 0;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? status)
        => Ok(await _service.GetAllAsync(status));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var e = await _service.GetByIdAsync(id);
        return e is null ? NotFound() : Ok(e);
    }

    [HttpGet("reasons")]
    public IActionResult GetReasons() => Ok(ExitReason.All);

    [HttpGet("statuses")]
    public IActionResult GetStatuses() => Ok(ExitStatus.All);

    /// <summary>Step 1 — raise an exit request (Operations / Yard / Admin)</summary>
    [HttpPost]
    [Authorize(Roles = "Admin,Operations,Yard")]
    public async Task<IActionResult> Create([FromBody] CreateExitRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var (ok, err, id) = await _service.CreateAsync(request, CurrentUserId);
        if (!ok) return BadRequest(new { message = err });
        return Ok(new { message = "Exit request created", id });
    }

    /// <summary>Step 2 — Admin approves (issues single-use OTP) or rejects</summary>
    [HttpPost("{id:int}/approve")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Approve(int id, [FromBody] ApproveExitRequest request)
    {
        var (ok, err, otp) = await _service.ApproveAsync(id, request, CurrentUserId);
        if (!ok) return BadRequest(new { message = err });
        // otp is null on rejection
        return Ok(otp is null ? new { message = "Exit request rejected" } : (object)otp);
    }

    /// <summary>Step 3 — Yard verifies OTP to release the vehicle</summary>
    [HttpPost("{id:int}/verify-otp")]
    [Authorize(Roles = "Admin,Operations,Yard")]
    public async Task<IActionResult> VerifyOtp(int id, [FromBody] VerifyOtpRequest request)
    {
        var (ok, err) = await _service.VerifyOtpAsync(id, request.Otp);
        if (!ok) return BadRequest(new { message = err });
        return Ok(new { message = "OTP verified — vehicle released successfully" });
    }

    /// <summary>Regenerate an expired OTP (Admin)</summary>
    [HttpPost("{id:int}/regenerate-otp")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> RegenerateOtp(int id)
    {
        var (ok, err, otp) = await _service.RegenerateOtpAsync(id);
        if (!ok) return BadRequest(new { message = err });
        return Ok(otp);
    }

    [HttpPost("{id:int}/cancel")]
    [Authorize(Roles = "Admin,Operations")]
    public async Task<IActionResult> Cancel(int id)
        => await _service.CancelAsync(id) ? NoContent() : NotFound();
}
