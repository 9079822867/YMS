using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YMS.Application.DTOs;
using YMS.Application.Interfaces;
using YMS.Domain.Entities;

namespace YMS.API.Controllers;

[ApiController]
[Route("api/auctions")]
[Authorize]
public class AuctionController : ControllerBase
{
    private readonly IAuctionService _service;
    public AuctionController(IAuctionService service) => _service = service;

    private int Uid => int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var i) ? i : 0;

    [HttpGet] public async Task<IActionResult> GetAll([FromQuery] string? status) => Ok(await _service.GetAllAsync(status));
    [HttpGet("statuses")] public IActionResult Statuses() => Ok(AuctionStatus.All);
    [HttpGet("platforms")] public IActionResult Platforms() => Ok(AuctionStatus.Platforms);

    [HttpPost]
    [Authorize(Roles = "Admin,Operations")]
    public async Task<IActionResult> Create([FromBody] CreateAuctionRequest req)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var (ok, err, id) = await _service.CreateAsync(req, Uid);
        return ok ? Ok(new { message = "Vehicle listed for auction", id }) : BadRequest(new { message = err });
    }

    [HttpPost("{id:int}/bid")]
    [Authorize(Roles = "Admin,Operations")]
    public async Task<IActionResult> Bid(int id, [FromBody] RecordBidRequest req)
    {
        var (ok, err) = await _service.RecordBidAsync(id, req.BidAmount);
        return ok ? NoContent() : BadRequest(new { message = err });
    }

    [HttpPost("{id:int}/sell")]
    [Authorize(Roles = "Admin,Operations")]
    public async Task<IActionResult> Sell(int id, [FromBody] CompleteSaleRequest req)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var (ok, err) = await _service.CompleteSaleAsync(id, req);
        return ok ? NoContent() : BadRequest(new { message = err });
    }

    [HttpPost("{id:int}/unsold")]
    [Authorize(Roles = "Admin,Operations")]
    public async Task<IActionResult> Unsold(int id)
    {
        var (ok, err) = await _service.MarkUnsoldAsync(id);
        return ok ? NoContent() : BadRequest(new { message = err });
    }

    [HttpPost("{id:int}/cancel")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Cancel(int id) => await _service.CancelAsync(id) ? NoContent() : NotFound();
}
