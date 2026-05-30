using YMS.Application.DTOs;

namespace YMS.Application.Interfaces;

public class ImportResult
{
    public int TotalRows { get; set; }
    public int SuccessCount { get; set; }
    public int FailedCount { get; set; }
    public List<ImportError> Errors { get; set; } = new();
}

public class ImportError
{
    public int Row { get; set; }
    public string Field { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}

public interface IExcelService
{
    /// <summary>Export current inventory search to Excel bytes</summary>
    Task<byte[]> ExportInventoryAsync(VehicleSearchRequest request);

    /// <summary>Download a filled sample template</summary>
    byte[] GenerateSampleTemplate();

    /// <summary>Parse uploaded Excel and bulk-insert vehicles</summary>
    Task<ImportResult> ImportInventoryAsync(Stream stream);
}
