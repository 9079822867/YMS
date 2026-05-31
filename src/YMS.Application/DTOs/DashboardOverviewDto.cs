namespace YMS.Application.DTOs;

public class DashboardOverviewDto
{
    // ── KPI row 1 ──
    public int TotalInventory { get; set; }
    public int EntryThisMonth { get; set; }
    public int EntryLastMonth { get; set; }
    public int EntryToday { get; set; }
    public int ExitThisMonth { get; set; }
    public int ExitLastMonth { get; set; }
    public int ExitToday { get; set; }
    public int TotalExitedAllTime { get; set; }

    // ── KPI row 2 ──
    public int Over30DaysStock { get; set; }
    public int LegalHoldStock { get; set; }
    public int UpcomingAuction { get; set; }
    public int AuctionCompleted { get; set; }
    public double AverageHoldingDays { get; set; }
    public double OccupancyPercent { get; set; }

    // ── Footer ──
    public int TotalYards { get; set; }
    public int ActiveUsers { get; set; }

    // ── % deltas (computed) ──
    public double EntryMonthDelta => Pct(EntryThisMonth, EntryLastMonth);
    public double ExitMonthDelta  => Pct(ExitThisMonth, ExitLastMonth);

    // ── Charts ──
    public List<TrendPoint> InventoryTrend { get; set; } = new();
    public List<EntryExitPoint> EntriesExits { get; set; } = new();
    public List<VehicleTypeSlice> VehicleTypeDistribution { get; set; } = new();

    // ── Tables ──
    public List<RecentVehicleDto> RecentVehicles { get; set; } = new();
    public List<YardInventoryDto> YardWiseInventory { get; set; } = new();

    private static double Pct(int cur, int prev)
        => prev == 0 ? (cur > 0 ? 100 : 0) : Math.Round((cur - prev) * 100.0 / prev, 1);
}

public class TrendPoint
{
    public string Date { get; set; } = string.Empty;
    public int Count { get; set; }
}

public class EntryExitPoint
{
    public string Date { get; set; } = string.Empty;
    public int Entries { get; set; }
    public int Exits { get; set; }
}

public class VehicleTypeSlice
{
    public string Type { get; set; } = string.Empty;
    public int Count { get; set; }
    public double Percent { get; set; }
}

public class RecentVehicleDto
{
    public string RegistrationNumber { get; set; } = string.Empty;
    public string Vehicle { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public DateTime EntryDate { get; set; }
    public string Yard { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}

public class YardInventoryDto
{
    public string Yard { get; set; } = string.Empty;
    public int Total { get; set; }
    public int Capacity { get; set; }
    public double OccupancyPercent { get; set; }
    public int Over30Days { get; set; }
}
