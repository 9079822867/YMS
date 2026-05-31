using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YMS.Application.Interfaces;

namespace YMS.API.Controllers;

[ApiController]
[Route("api/notifications")]
[Authorize]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _service;
    public NotificationController(INotificationService service) => _service = service;

    private int Uid => int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var i) ? i : 0;

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] bool unreadOnly = false)
        => Ok(await _service.GetForUserAsync(Uid, unreadOnly));

    [HttpGet("unread-count")]
    public async Task<IActionResult> UnreadCount() => Ok(new { count = await _service.GetUnreadCountAsync(Uid) });

    [HttpPost("{id:int}/read")]
    public async Task<IActionResult> MarkRead(int id) => await _service.MarkReadAsync(id) ? NoContent() : NotFound();

    [HttpPost("read-all")]
    public async Task<IActionResult> MarkAllRead() { await _service.MarkAllReadAsync(Uid); return NoContent(); }
}
