namespace YMS.Domain.Entities;

public class Report : BaseEntity
{
    public int VehicleId { get; set; }
    public string ReportType { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string Status { get; set; } = "Pending";
    public int UploadedBy { get; set; }
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

    public Vehicle Vehicle { get; set; } = null!;
}
