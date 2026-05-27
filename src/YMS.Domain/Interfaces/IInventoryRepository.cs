using YMS.Domain.Entities;

namespace YMS.Domain.Interfaces;

public interface IInventoryRepository : IRepository<Vehicle>
{
    Task<(IEnumerable<Vehicle> Items, int TotalCount)> SearchAsync(
        string? clientName, string? state, string? yardName, string? yardCity,
        string? vehicleType, string? loanNumber, string? registrationNumber,
        string? chassisNumber, string? engineNumber, string? runningStatus,
        string? keyStatus, string? rcStatus, DateTime? entryFrom, DateTime? entryTo,
        int page, int pageSize);

    Task<DashboardStats> GetDashboardStatsAsync();
}

public class DashboardStats
{
    public int TotalVehicles { get; set; }
    public int RunningVehicles { get; set; }
    public int IdleVehicles { get; set; }
    public int PendingRc { get; set; }
    public int SubmittedReports { get; set; }
    public decimal TotalParkingCharges { get; set; }
    public int ActiveYards { get; set; }
}
