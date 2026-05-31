namespace YMS.Domain.Entities;

/// <summary>Module 8 — Auction Management. Vehicle disposal via auction.</summary>
public class Auction : BaseEntity
{
    public int VehicleId { get; set; }
    public string Status { get; set; } = AuctionStatus.Listed;
    public string? Platform { get; set; }            // MSTC, C1 India, Internal
    public decimal ReservePrice { get; set; }
    public decimal? HighestBid { get; set; }
    public decimal? SalePrice { get; set; }
    public string? BuyerName { get; set; }
    public string? BuyerContact { get; set; }
    public DateTime? AuctionDate { get; set; }
    public DateTime? SoldAt { get; set; }
    public string? Notes { get; set; }
    public int CreatedBy { get; set; }

    public Vehicle Vehicle { get; set; } = null!;
}

public static class AuctionStatus
{
    public const string Listed  = "Listed";
    public const string BidOpen = "Bid Open";
    public const string Sold    = "Sold";
    public const string Unsold  = "Unsold";
    public const string Cancelled = "Cancelled";
    public static readonly string[] All = { Listed, BidOpen, Sold, Unsold, Cancelled };
    public static readonly string[] Platforms = { "MSTC", "C1 India", "Internal" };
}
