using YMS.Application.DTOs;
using YMS.Application.Interfaces;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;

namespace YMS.Application.Services;

public class NotificationService : INotificationService
{
    private readonly IRepository<Notification> _repo;

    public NotificationService(IRepository<Notification> repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<NotificationDto>> GetForUserAsync(int userId, bool unreadOnly)
    {
        var all = await _repo.FindAsync(n => (n.UserId == userId || n.UserId == null) && !n.IsDeleted);
        if (unreadOnly) all = all.Where(n => !n.IsRead);
        return all.OrderByDescending(n => n.CreatedAt).Take(100).Select(Map);
    }

    public async Task<int> GetUnreadCountAsync(int userId)
    {
        var all = await _repo.FindAsync(n => (n.UserId == userId || n.UserId == null) && !n.IsRead && !n.IsDeleted);
        return all.Count();
    }

    public async Task CreateAsync(int? userId, string title, string message, string type = "Info", string? link = null)
    {
        await _repo.AddAsync(new Notification { UserId = userId, Title = title, Message = message, Type = type, Link = link });
        await _repo.SaveChangesAsync();
        // NOTE: Email / SMS / WhatsApp channels are stubbed — integrate gateway here when keys are available.
    }

    public async Task<bool> MarkReadAsync(int id)
    {
        var n = await _repo.GetByIdAsync(id);
        if (n is null) return false;
        n.IsRead = true; n.UpdatedAt = DateTime.UtcNow;
        _repo.Update(n);
        await _repo.SaveChangesAsync();
        return true;
    }

    public async Task MarkAllReadAsync(int userId)
    {
        var unread = await _repo.FindAsync(n => (n.UserId == userId || n.UserId == null) && !n.IsRead && !n.IsDeleted);
        foreach (var n in unread) { n.IsRead = true; n.UpdatedAt = DateTime.UtcNow; _repo.Update(n); }
        await _repo.SaveChangesAsync();
    }

    private static NotificationDto Map(Notification n) => new()
    {
        Id = n.Id, Title = n.Title, Message = n.Message, Type = n.Type,
        Link = n.Link, IsRead = n.IsRead, CreatedAt = n.CreatedAt
    };
}
