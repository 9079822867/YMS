namespace YMS.Domain.Entities;

/// <summary>
/// Module 9 — Exit Control. Governs authorised release of a vehicle from a yard.
/// Workflow: Pending → Approved (OTP generated) → Completed | Rejected | Cancelled
/// Security: dual-step approval, single-use + expiring OTP, QR gate pass.
/// </summary>
public class VehicleExitRequest : BaseEntity
{
    public int VehicleId { get; set; }

    // Who & why
    public int RequestedBy { get; set; }
    public string ExitReason { get; set; } = string.Empty;   // Auction Sale, Borrower Release, Inter-Yard Transfer, Scrap Disposal
    public string ReceiverName { get; set; } = string.Empty;
    public string ReceiverContact { get; set; } = string.Empty;
    public string? ReceiverIdProof { get; set; }
    public string? Notes { get; set; }

    // Workflow state
    public string Status { get; set; } = ExitStatus.Pending;

    // Approval (dual control)
    public int? ApprovedBy { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public string? RejectionReason { get; set; }

    // OTP (single use + expiry)
    public string? OtpHash { get; set; }
    public DateTime? OtpExpiry { get; set; }
    public int OtpAttempts { get; set; }
    public DateTime? OtpVerifiedAt { get; set; }

    // Gate pass
    public string? GatePassCode { get; set; }

    // Completion
    public DateTime? ExitedAt { get; set; }

    public Vehicle Vehicle { get; set; } = null!;
}

public static class ExitStatus
{
    public const string Pending   = "Pending";     // awaiting approval
    public const string Approved  = "Approved";    // OTP generated, awaiting verification
    public const string Completed = "Completed";   // OTP verified, vehicle exited
    public const string Rejected  = "Rejected";
    public const string Cancelled = "Cancelled";
    public static readonly string[] All = { Pending, Approved, Completed, Rejected, Cancelled };
}

public static class ExitReason
{
    public const string AuctionSale     = "Auction Sale";
    public const string BorrowerRelease = "Borrower Release";
    public const string InterYardTransfer = "Inter-Yard Transfer";
    public const string ScrapDisposal   = "Scrap Disposal";
    public static readonly string[] All = { AuctionSale, BorrowerRelease, InterYardTransfer, ScrapDisposal };

    /// <summary>Running status the vehicle moves to once exit completes.</summary>
    public static string ToRunningStatus(string reason) => reason switch
    {
        AuctionSale     => "Sold",
        BorrowerRelease => "Released",
        ScrapDisposal   => "Scrap",
        _               => "Released"
    };
}
