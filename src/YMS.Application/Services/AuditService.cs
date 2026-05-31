using YMS.Application.DTOs;
using YMS.Application.Interfaces;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;

namespace YMS.Application.Services;

public class AuditService : IAuditService
{
    private readonly IRepository<AuditLog> _repo;

    public AuditService(IRepository<AuditLog> repo)
    {
        _repo = repo;
    }

    public async Task LogAsync(int userId, string action, string entityType, int? entityId = null, string? details = null, string? ip = null)
    {
        await _repo.AddAsync(new AuditLog
        {
            UserId = userId, Action = action, EntityType = entityType,
            EntityId = entityId, Details = details, IpAddress = ip ?? string.Empty,
            Timestamp = DateTime.UtcNow
        });
        await _repo.SaveChangesAsync();
    }

    public async Task<IEnumerable<AuditLogDto>> GetRecentAsync(int take, string? entityType)
    {
        var all = await _repo.GetAllAsync();
        var q = all.AsEnumerable();
        if (!string.IsNullOrWhiteSpace(entityType)) q = q.Where(a => a.EntityType == entityType);
        return q.OrderByDescending(a => a.Timestamp).Take(take <= 0 ? 100 : take).Select(Map);
    }

    private static AuditLogDto Map(AuditLog a) => new()
    {
        Id = a.Id, UserId = a.UserId, Action = a.Action, EntityType = a.EntityType,
        EntityId = a.EntityId, Details = a.Details, IpAddress = a.IpAddress, Timestamp = a.Timestamp
    };
}
