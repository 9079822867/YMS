using Moq;
using Xunit;
using YMS.Application.DTOs;
using YMS.Application.Services;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;

namespace YMS.Tests;

public class AuctionServiceTests
{
    private readonly Mock<IAuctionRepository> _repo = new();
    private readonly Mock<IRepository<Vehicle>> _veh = new();
    private readonly AuctionService _service;

    public AuctionServiceTests()
    {
        _service = new AuctionService(_repo.Object, _veh.Object);
        _repo.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);
        _veh.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);
    }

    [Fact]
    public async Task Create_Valid_ListsAndMarksVehicleAuctioned()
    {
        var v = new Vehicle { Id = 1, RunningStatus = "Running" };
        _veh.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(v);
        _repo.Setup(r => r.AddAsync(It.IsAny<Auction>())).Returns(Task.CompletedTask);

        var (ok, _, _) = await _service.CreateAsync(new CreateAuctionRequest { VehicleId = 1, ReservePrice = 100000, Platform = "MSTC" }, 5);
        Assert.True(ok);
        Assert.Equal("Auctioned", v.RunningStatus);
    }

    [Fact]
    public async Task Create_ZeroReserve_Fails()
    {
        _veh.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Vehicle { Id = 1 });
        var (ok, err, _) = await _service.CreateAsync(new CreateAuctionRequest { VehicleId = 1, ReservePrice = 0 }, 5);
        Assert.False(ok);
        Assert.Contains("Reserve price", err);
    }

    [Fact]
    public async Task Bid_BelowReserve_Fails()
    {
        _repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Auction { Id = 1, ReservePrice = 100000, Status = AuctionStatus.Listed });
        var (ok, err) = await _service.RecordBidAsync(1, 90000);
        Assert.False(ok);
        Assert.Contains("reserve price", err);
    }

    [Fact]
    public async Task Bid_Valid_SetsHighestAndBidOpen()
    {
        var a = new Auction { Id = 1, ReservePrice = 100000, Status = AuctionStatus.Listed };
        _repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(a);
        Assert.True((await _service.RecordBidAsync(1, 120000)).Success);
        Assert.Equal(120000, a.HighestBid);
        Assert.Equal(AuctionStatus.BidOpen, a.Status);
    }

    [Fact]
    public async Task Bid_NotHigherThanCurrent_Fails()
    {
        var a = new Auction { Id = 1, ReservePrice = 100000, HighestBid = 120000, Status = AuctionStatus.BidOpen };
        _repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(a);
        var (ok, err) = await _service.RecordBidAsync(1, 110000);
        Assert.False(ok);
        Assert.Contains("exceed current highest", err);
    }

    [Fact]
    public async Task Sell_Valid_MarksSoldAndVehicleSold()
    {
        var a = new Auction { Id = 1, ReservePrice = 100000, Status = AuctionStatus.BidOpen, VehicleId = 1 };
        var v = new Vehicle { Id = 1, RunningStatus = "Auctioned" };
        _repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(a);
        _veh.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(v);

        var (ok, _) = await _service.CompleteSaleAsync(1, new CompleteSaleRequest { SalePrice = 130000, BuyerName = "Buyer X" });
        Assert.True(ok);
        Assert.Equal(AuctionStatus.Sold, a.Status);
        Assert.Equal(130000, a.SalePrice);
        Assert.Equal("Sold", v.RunningStatus);
    }

    [Fact]
    public async Task Sell_BelowReserve_Fails()
    {
        _repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Auction { Id = 1, ReservePrice = 100000, Status = AuctionStatus.BidOpen });
        var (ok, err) = await _service.CompleteSaleAsync(1, new CompleteSaleRequest { SalePrice = 80000, BuyerName = "X" });
        Assert.False(ok);
        Assert.Contains("below reserve", err);
    }
}
