namespace YMS.Application.DTOs;

public class VehicleDocumentDto
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public string Category { get; set; } = string.Empty;
    public string DocumentType { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public long FileSize { get; set; }
    public string ContentType { get; set; } = string.Empty;
    public int Version { get; set; }
    public DateTime CreatedAt { get; set; }
    public string DownloadUrl => $"/api/documents/{Id}/download";
}
