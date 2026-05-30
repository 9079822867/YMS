using System.ComponentModel.DataAnnotations;

namespace YMS.Application.DTOs;

public class ProjectListDto
{
    public int Id { get; set; }
    public string ProjectName { get; set; } = string.Empty;
    public string ClientName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? AssignedTo { get; set; }
    public int VehicleCount { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class ProjectDetailDto : ProjectListDto
{
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public int ClientId { get; set; }
    public int? AssignedUserId { get; set; }
}

public class SaveProjectRequest
{
    [Required] public string ProjectName { get; set; } = string.Empty;
    public string? Description { get; set; }
    [Required] public int ClientId { get; set; }
    public int? AssignedUserId { get; set; }
    [Required] public string Status { get; set; } = "Active";
    [Required] public string Priority { get; set; } = "Medium";
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    public DateTime? EndDate { get; set; }
    public string? Notes { get; set; }
}

public class ProjectSearchRequest
{
    public string? ProjectName { get; set; }
    public string? ClientName { get; set; }
    public string? Status { get; set; }
    public string? Priority { get; set; }
    public DateTime? StartFrom { get; set; }
    public DateTime? StartTo { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 25;
}
