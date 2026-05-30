namespace YMS.Domain.Entities;

public class Project : BaseEntity
{
    public string ProjectName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int ClientId { get; set; }
    public int? AssignedUserId { get; set; }

    public string Status { get; set; } = "Active";       // Active, On Hold, Completed, Cancelled
    public string Priority { get; set; } = "Medium";     // High, Medium, Low
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    public DateTime? EndDate { get; set; }
    public string? Notes { get; set; }

    public Client Client { get; set; } = null!;
    public User? AssignedUser { get; set; }
    public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}

public static class ProjectStatus
{
    public const string Active    = "Active";
    public const string OnHold    = "On Hold";
    public const string Completed = "Completed";
    public const string Cancelled = "Cancelled";
    public static readonly string[] All = { Active, OnHold, Completed, Cancelled };
}

public static class ProjectPriority
{
    public const string High   = "High";
    public const string Medium = "Medium";
    public const string Low    = "Low";
    public static readonly string[] All = { High, Medium, Low };
}
