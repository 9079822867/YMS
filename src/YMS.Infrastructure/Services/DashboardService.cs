using Microsoft.EntityFrameworkCore;
using YMS.Application.DTOs;
using YMS.Application.Interfaces;
using YMS.Domain.Entities;
using YMS.Infrastructure.Data;

namespace YMS.Infrastructure.Services;

public class DashboardService : IDashboardService
{
    private readonly YmsDbContext _db;

    public DashboardService(YmsDbContext db) => _db = db;

    public async Task<DashboardOverviewDto> GetOverviewAsync()
    {
        var now        = DateTime.UtcNow;
        var today      = now.Date;
        var monthStart = new DateTime(now.Year, now.Month, 1);
        var lastMonth  = monthStart.AddMonths(-1);
        var cutoff30   = today.AddDays(-30);

        // Pull a lean projection of all (non-deleted) vehicles once
        var vehicles = await _db.Vehicles
            .Select(v => new { v.Id, v.EntryDate, v.ExitDate, v.VehicleType, v.IsLegalHold, v.YardId })
            .ToListAsync();

        var inYard = vehicles.Where(v => v.ExitDate == null).ToList();

        var dto = new DashboardOverviewDto
        {
            TotalInventory     = inYard.Count,
            EntryThisMonth     = vehicles.Count(v => v.EntryDate >= monthStart),
            EntryLastMonth     = vehicles.Count(v => v.EntryDate >= lastMonth && v.EntryDate < monthStart),
            EntryToday         = vehicles.Count(v => v.EntryDate >= today),
            ExitThisMonth      = vehicles.Count(v => v.ExitDate != null && v.ExitDate >= monthStart),
            ExitLastMonth      = vehicles.Count(v => v.ExitDate != null && v.ExitDate >= lastMonth && v.ExitDate < monthStart),
            ExitToday          = vehicles.Count(v => v.ExitDate != null && v.ExitDate >= today),
            TotalExitedAllTime = vehicles.Count(v => v.ExitDate != null),
            Over30DaysStock    = inYard.Count(v => v.EntryDate <= cutoff30),
            LegalHoldStock     = inYard.Count(v => v.IsLegalHold),
        };

        // Average holding days (in-yard vehicles)
        dto.AverageHoldingDays = inYard.Count == 0 ? 0
            : Math.Round(inYard.Average(v => (now - v.EntryDate).TotalDays), 1);

        // Auctions this month
        var auctions = await _db.Auctions.Select(a => new { a.Status, a.AuctionDate, a.SoldAt }).ToListAsync();
        dto.UpcomingAuction  = auctions.Count(a => (a.Status == AuctionStatus.Listed || a.Status == AuctionStatus.BidOpen)
                                                    && a.AuctionDate != null && a.AuctionDate >= monthStart);
        dto.AuctionCompleted = auctions.Count(a => a.Status == AuctionStatus.Sold && a.SoldAt != null && a.SoldAt >= monthStart);

        // Yards + occupancy
        var yards = await _db.Yards.Where(y => y.IsActive)
            .Select(y => new { y.Id, y.Name, y.Capacity }).ToListAsync();
        dto.TotalYards   = yards.Count;
        dto.ActiveUsers  = await _db.Users.CountAsync(u => u.IsActive);

        var totalCapacity = yards.Sum(y => y.Capacity);
        dto.OccupancyPercent = totalCapacity == 0 ? 0
            : Math.Round(inYard.Count * 100.0 / totalCapacity, 1);

        // ── Charts: last 7 days ──
        for (int i = 6; i >= 0; i--)
        {
            var day     = today.AddDays(-i);
            var nextDay = day.AddDays(1);
            var label   = day.ToString("MMM dd");

            // Inventory in-yard as-of end of that day
            dto.InventoryTrend.Add(new TrendPoint
            {
                Date  = label,
                Count = vehicles.Count(v => v.EntryDate < nextDay && (v.ExitDate == null || v.ExitDate >= nextDay))
            });

            dto.EntriesExits.Add(new EntryExitPoint
            {
                Date    = label,
                Entries = vehicles.Count(v => v.EntryDate >= day && v.EntryDate < nextDay),
                Exits   = vehicles.Count(v => v.ExitDate != null && v.ExitDate >= day && v.ExitDate < nextDay)
            });
        }

        // ── Vehicle-type distribution (in-yard) ──
        var total = Math.Max(1, inYard.Count);
        dto.VehicleTypeDistribution = inYard
            .GroupBy(v => string.IsNullOrWhiteSpace(v.VehicleType) ? "Other" : v.VehicleType)
            .Select(g => new VehicleTypeSlice
            {
                Type    = g.Key,
                Count   = g.Count(),
                Percent = Math.Round(g.Count() * 100.0 / total, 1)
            })
            .OrderByDescending(s => s.Count)
            .ToList();

        // ── Recently added vehicles (last 5) ──
        dto.RecentVehicles = await _db.Vehicles
            .Include(v => v.Yard)
            .OrderByDescending(v => v.CreatedAt)
            .Take(5)
            .Select(v => new RecentVehicleDto
            {
                RegistrationNumber = v.RegistrationNumber,
                Vehicle  = ((v.Make ?? "") + " " + (v.Model ?? "")).Trim(),
                Category = v.VehicleType,
                EntryDate = v.EntryDate,
                Yard     = v.Yard.Name,
                Status   = v.RunningStatus
            })
            .ToListAsync();

        // ── Yard-wise inventory ──
        dto.YardWiseInventory = yards.Select(y =>
        {
            var yv = inYard.Where(v => v.YardId == y.Id).ToList();
            return new YardInventoryDto
            {
                Yard             = y.Name,
                Total            = yv.Count,
                Capacity         = y.Capacity,
                OccupancyPercent = y.Capacity == 0 ? 0 : Math.Round(yv.Count * 100.0 / y.Capacity, 1),
                Over30Days       = yv.Count(v => v.EntryDate <= cutoff30)
            };
        })
        .OrderByDescending(y => y.Total)
        .ToList();

        return dto;
    }
}
