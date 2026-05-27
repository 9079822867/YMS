namespace YMS.Application.DTOs;

public class DashboardResponse
{
    public int TotalVehicles { get; set; }
    public int RunningVehicles { get; set; }
    public int IdleVehicles { get; set; }
    public int PendingRc { get; set; }
    public int SubmittedReports { get; set; }
    public decimal TotalParkingCharges { get; set; }
    public int ActiveYards { get; set; }
}

public class PagedResult<T>
{
    public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    public int TotalCount { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
}
