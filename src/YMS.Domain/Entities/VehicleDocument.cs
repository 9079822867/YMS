namespace YMS.Domain.Entities;

/// <summary>Module 6 — Document Management Vault. Stores files attached to a vehicle.</summary>
public class VehicleDocument : BaseEntity
{
    public int VehicleId { get; set; }
    public string Category { get; set; } = DocumentCategory.Document;   // Document | Image
    public string DocumentType { get; set; } = string.Empty;            // RC, Insurance, Memo, Front, Rear, Damage…
    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;                // relative path under uploads/
    public long FileSize { get; set; }
    public string ContentType { get; set; } = string.Empty;
    public int Version { get; set; } = 1;
    public int UploadedBy { get; set; }

    public Vehicle Vehicle { get; set; } = null!;
}

public static class DocumentCategory
{
    public const string Document = "Document";
    public const string Image    = "Image";
}

public static class DocumentType
{
    // Documents
    public static readonly string[] Documents =
        { "RC", "Insurance", "Loan Document", "Repossession Memo", "Valuation Report", "Gate Pass", "Auction Report", "Yard Receipt" };
    // Images
    public static readonly string[] Images =
        { "Front", "Rear", "Left", "Right", "Chassis", "Odometer", "Damage" };
}
