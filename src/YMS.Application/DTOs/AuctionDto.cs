using System.ComponentModel.DataAnnotations;

namespace YMS.Application.DTOs;

public class AuctionListDto
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public string RegistrationNumber { get; set; } = string.Empty;
    public string ClientName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string? Platform { get; set; }
    public decimal ReservePrice { get; set; }
    public decimal? HighestBid { get; set; }
    public decimal? SalePrice { get; set; }
    public string? BuyerName { get; set; }
    public DateTime? AuctionDate { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class CreateAuctionRequest
{
    [Required] public int VehicleId { get; set; }
    public string? Platform { get; set; }
    [Required] public decimal ReservePrice { get; set; }
    public DateTime? AuctionDate { get; set; }
    public string? Notes { get; set; }
}

public class RecordBidRequest
{
    [Required] public decimal BidAmount { get; set; }
}

public class CompleteSaleRequest
{
    [Required] public decimal SalePrice { get; set; }
    [Required] public string BuyerName { get; set; } = string.Empty;
    public string? BuyerContact { get; set; }
}
