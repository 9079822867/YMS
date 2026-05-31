namespace YMS.Domain.Entities;

/// <summary>Module 5 — Inspection & Valuation. Triggered after vehicle entry.</summary>
public class Inspection : BaseEntity
{
    public int VehicleId { get; set; }
    public string Status { get; set; } = InspectionStatus.Requested;
    public string? ValuationAgency { get; set; }
    public DateTime? ScheduledDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public decimal? ValuationAmount { get; set; }
    public string? ReportPath { get; set; }
    public string? Notes { get; set; }
    public int RequestedBy { get; set; }

    public Vehicle Vehicle { get; set; } = null!;
}

public static class InspectionStatus
{
    public const string Requested = "Requested";
    public const string Scheduled = "Scheduled";
    public const string Completed = "Completed";
    public const string Cancelled = "Cancelled";
    public static readonly string[] All = { Requested, Scheduled, Completed, Cancelled };
}
