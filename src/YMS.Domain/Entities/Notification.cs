namespace YMS.Domain.Entities;

/// <summary>Module 13 — Notification Engine (in-app channel; email/SMS/WhatsApp stubbed).</summary>
public class Notification : BaseEntity
{
    public int? UserId { get; set; }              // null = broadcast to all
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string Type { get; set; } = "Info";    // Info, Alert, Warning, Success
    public string? Link { get; set; }             // optional in-app navigation target
    public bool IsRead { get; set; } = false;
}
