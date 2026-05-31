namespace YMS.Domain.Entities;

/// <summary>Module 7 — Inter-Yard Transfer. Tracks vehicle movement between yards.</summary>
public class VehicleTransfer : BaseEntity
{
    public int VehicleId { get; set; }
    public int FromYardId { get; set; }
    public int ToYardId { get; set; }

    public string Status { get; set; } = TransferStatus.Requested;
    public string? Reason { get; set; }
    public string? Notes { get; set; }

    public int RequestedBy { get; set; }
    public int? ApprovedBy { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public DateTime? DispatchedAt { get; set; }
    public DateTime? ReceivedAt { get; set; }
    public string? RejectionReason { get; set; }

    public Vehicle Vehicle { get; set; } = null!;
    public Yard FromYard { get; set; } = null!;
    public Yard ToYard { get; set; } = null!;
}

public static class TransferStatus
{
    public const string Requested  = "Requested";
    public const string Approved   = "Approved";
    public const string Dispatched = "Dispatched";
    public const string Received   = "Received";
    public const string Rejected   = "Rejected";
    public const string Cancelled  = "Cancelled";
    public static readonly string[] All = { Requested, Approved, Dispatched, Received, Rejected, Cancelled };
}
