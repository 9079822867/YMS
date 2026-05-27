using Microsoft.EntityFrameworkCore;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;
using YMS.Infrastructure.Data;

namespace YMS.Infrastructure.Repositories;

public class InventoryRepository : Repository<Vehicle>, IInventoryRepository
{
    public InventoryRepository(YmsDbContext context) : base(context) { }

    public async Task<(IEnumerable<Vehicle> Items, int TotalCount)> SearchAsync(
        string? clientName, string? state, string? yardName, string? yardCity,
        string? vehicleType, string? loanNumber, string? registrationNumber,
        string? chassisNumber, string? engineNumber, string? runningStatus,
        string? keyStatus, string? rcStatus, DateTime? entryFrom, DateTime? entryTo,
        int page, int pageSize)
    {
        var query = _dbSet
            .Include(v => v.Client)
            .Include(v => v.Yard)
            .Include(v => v.Reports)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(clientName))
            query = query.Where(v => v.Client.Name.Contains(clientName));
        if (!string.IsNullOrWhiteSpace(state))
            query = query.Where(v => v.Yard.State == state);
        if (!string.IsNullOrWhiteSpace(yardName))
            query = query.Where(v => v.Yard.Name.Contains(yardName));
        if (!string.IsNullOrWhiteSpace(yardCity))
            query = query.Where(v => v.Yard.City.Contains(yardCity));
        if (!string.IsNullOrWhiteSpace(vehicleType))
            query = query.Where(v => v.VehicleType == vehicleType);
        if (!string.IsNullOrWhiteSpace(loanNumber))
            query = query.Where(v => v.LoanNumber.Contains(loanNumber));
        if (!string.IsNullOrWhiteSpace(registrationNumber))
            query = query.Where(v => v.RegistrationNumber.Contains(registrationNumber));
        if (!string.IsNullOrWhiteSpace(chassisNumber))
            query = query.Where(v => v.ChassisNumber.Contains(chassisNumber));
        if (!string.IsNullOrWhiteSpace(engineNumber))
            query = query.Where(v => v.EngineNumber.Contains(engineNumber));
        if (!string.IsNullOrWhiteSpace(runningStatus))
            query = query.Where(v => v.RunningStatus == runningStatus);
        if (!string.IsNullOrWhiteSpace(keyStatus))
            query = query.Where(v => v.KeyStatus == keyStatus);
        if (!string.IsNullOrWhiteSpace(rcStatus))
            query = query.Where(v => v.RcStatus == rcStatus);
        if (entryFrom.HasValue)
            query = query.Where(v => v.EntryDate >= entryFrom.Value);
        if (entryTo.HasValue)
            query = query.Where(v => v.EntryDate <= entryTo.Value);

        var total = await query.CountAsync();
        var items = await query
            .OrderByDescending(v => v.EntryDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (items, total);
    }

    public async Task<DashboardStats> GetDashboardStatsAsync()
    {
        var vehicles = _dbSet.Include(v => v.Reports).Include(v => v.Yard);

        return new DashboardStats
        {
            TotalVehicles = await vehicles.CountAsync(),
            RunningVehicles = await vehicles.CountAsync(v => v.RunningStatus == "Running"),
            IdleVehicles = await vehicles.CountAsync(v => v.RunningStatus == "Red/Idle"),
            PendingRc = await vehicles.CountAsync(v => v.RcStatus == "Pending"),
            SubmittedReports = await _context.Reports.CountAsync(r => r.Status == "Approved"),
            TotalParkingCharges = await vehicles.SumAsync(v => v.ParkingCharges),
            ActiveYards = await _context.Yards.CountAsync(y => y.IsActive)
        };
    }
}
