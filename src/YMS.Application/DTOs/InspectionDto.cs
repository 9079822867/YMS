using System.ComponentModel.DataAnnotations;

namespace YMS.Application.DTOs;

public class InspectionListDto
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public string RegistrationNumber { get; set; } = string.Empty;
    public string ClientName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string? ValuationAgency { get; set; }
    public DateTime? ScheduledDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public decimal? ValuationAmount { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class CreateInspectionRequest
{
    [Required] public int VehicleId { get; set; }
    public string? ValuationAgency { get; set; }
    public DateTime? ScheduledDate { get; set; }
    public string? Notes { get; set; }
}

public class CompleteInspectionRequest
{
    [Required] public decimal ValuationAmount { get; set; }
    public string? Notes { get; set; }
}
