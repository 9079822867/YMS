using YMS.Application.DTOs;
using YMS.Application.Interfaces;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;

namespace YMS.Application.Services;

public class AuctionService : IAuctionService
{
    private readonly IAuctionRepository _repo;
    private readonly IRepository<Vehicle> _vehicleRepo;

    public AuctionService(IAuctionRepository repo, IRepository<Vehicle> vehicleRepo)
    {
        _repo = repo;
        _vehicleRepo = vehicleRepo;
    }

    public async Task<IEnumerable<AuctionListDto>> GetAllAsync(string? status)
        => (await _repo.GetAllWithDetailsAsync(status)).Select(Map);

    public async Task<(bool Success, string Error, int Id)> CreateAsync(CreateAuctionRequest request, int userId)
    {
        var vehicle = await _vehicleRepo.GetByIdAsync(request.VehicleId);
        if (vehicle is null) return (false, "Vehicle not found", 0);
        if (request.ReservePrice <= 0) return (false, "Reserve price must be greater than zero", 0);

        var a = new Auction
        {
            VehicleId    = request.VehicleId,
            Platform     = request.Platform,
            ReservePrice = request.ReservePrice,
            AuctionDate  = request.AuctionDate,
            Notes        = request.Notes,
            Status       = AuctionStatus.Listed,
            CreatedBy    = userId
        };
        await _repo.AddAsync(a);
        await _repo.SaveChangesAsync();

        vehicle.RunningStatus = "Auctioned";
        vehicle.UpdatedAt = DateTime.UtcNow;
        _vehicleRepo.Update(vehicle);
        await _vehicleRepo.SaveChangesAsync();

        return (true, string.Empty, a.Id);
    }

    public async Task<(bool Success, string Error)> RecordBidAsync(int id, decimal bid)
    {
        var a = await _repo.GetByIdAsync(id);
        if (a is null) return (false, "Auction not found");
        if (a.Status is AuctionStatus.Sold or AuctionStatus.Cancelled) return (false, "Auction is closed");
        if (bid < a.ReservePrice) return (false, $"Bid must be at least the reserve price (₹{a.ReservePrice:N0})");
        if (a.HighestBid.HasValue && bid <= a.HighestBid) return (false, $"Bid must exceed current highest (₹{a.HighestBid:N0})");

        a.HighestBid = bid;
        a.Status     = AuctionStatus.BidOpen;
        a.UpdatedAt  = DateTime.UtcNow;
        _repo.Update(a);
        await _repo.SaveChangesAsync();
        return (true, string.Empty);
    }

    public async Task<(bool Success, string Error)> CompleteSaleAsync(int id, CompleteSaleRequest request)
    {
        var a = await _repo.GetByIdAsync(id);
        if (a is null) return (false, "Auction not found");
        if (a.Status is AuctionStatus.Sold or AuctionStatus.Cancelled) return (false, "Auction is already closed");
        if (request.SalePrice < a.ReservePrice) return (false, "Sale price cannot be below reserve price");

        a.Status       = AuctionStatus.Sold;
        a.SalePrice    = request.SalePrice;
        a.BuyerName    = request.BuyerName;
        a.BuyerContact = request.BuyerContact;
        a.SoldAt       = DateTime.UtcNow;
        a.UpdatedAt    = DateTime.UtcNow;
        _repo.Update(a);

        var vehicle = await _vehicleRepo.GetByIdAsync(a.VehicleId);
        if (vehicle is not null) { vehicle.RunningStatus = "Sold"; vehicle.UpdatedAt = DateTime.UtcNow; _vehicleRepo.Update(vehicle); }

        await _repo.SaveChangesAsync();
        return (true, string.Empty);
    }

    public async Task<(bool Success, string Error)> MarkUnsoldAsync(int id)
    {
        var a = await _repo.GetByIdAsync(id);
        if (a is null) return (false, "Auction not found");
        if (a.Status is AuctionStatus.Sold) return (false, "Auction already sold");
        a.Status = AuctionStatus.Unsold;
        a.UpdatedAt = DateTime.UtcNow;
        _repo.Update(a);
        await _repo.SaveChangesAsync();
        return (true, string.Empty);
    }

    public async Task<bool> CancelAsync(int id)
    {
        var a = await _repo.GetByIdAsync(id);
        if (a is null || a.Status == AuctionStatus.Sold) return false;
        a.Status = AuctionStatus.Cancelled;
        a.UpdatedAt = DateTime.UtcNow;
        _repo.Update(a);
        await _repo.SaveChangesAsync();
        return true;
    }

    private static AuctionListDto Map(Auction a) => new()
    {
        Id = a.Id, VehicleId = a.VehicleId,
        RegistrationNumber = a.Vehicle?.RegistrationNumber ?? string.Empty,
        ClientName = a.Vehicle?.Client?.Name ?? string.Empty,
        Status = a.Status, Platform = a.Platform,
        ReservePrice = a.ReservePrice, HighestBid = a.HighestBid, SalePrice = a.SalePrice,
        BuyerName = a.BuyerName, AuctionDate = a.AuctionDate, CreatedAt = a.CreatedAt
    };
}
