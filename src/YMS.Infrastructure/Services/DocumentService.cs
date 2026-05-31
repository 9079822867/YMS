using Microsoft.Extensions.Configuration;
using YMS.Application.DTOs;
using YMS.Application.Interfaces;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;

namespace YMS.Infrastructure.Services;

public class DocumentService : IDocumentService
{
    private readonly IRepository<VehicleDocument> _repo;
    private readonly string _basePath;

    private static readonly string[] AllowedExtensions =
        { ".pdf", ".jpg", ".jpeg", ".png", ".gif", ".webp", ".doc", ".docx", ".xls", ".xlsx" };
    private const long MaxFileSize = 15 * 1024 * 1024; // 15 MB

    public DocumentService(IRepository<VehicleDocument> repo, IConfiguration config)
    {
        _repo = repo;
        _basePath = config["FileStorage:BasePath"]
            ?? Path.Combine(Directory.GetCurrentDirectory(), "uploads");
        Directory.CreateDirectory(_basePath);
    }

    public async Task<IEnumerable<VehicleDocumentDto>> GetForVehicleAsync(int vehicleId)
    {
        var docs = await _repo.FindAsync(d => d.VehicleId == vehicleId && !d.IsDeleted);
        return docs.OrderBy(d => d.Category).ThenBy(d => d.DocumentType).ThenByDescending(d => d.Version).Select(Map);
    }

    public async Task<(bool Success, string Error, VehicleDocumentDto? Doc)> UploadAsync(
        int vehicleId, string category, string documentType, string fileName,
        string contentType, byte[] content, int userId)
    {
        if (content.Length == 0) return (false, "Empty file", null);
        if (content.Length > MaxFileSize) return (false, "File exceeds 15 MB limit", null);

        var ext = Path.GetExtension(fileName).ToLowerInvariant();
        if (!AllowedExtensions.Contains(ext))
            return (false, $"File type '{ext}' not allowed", null);

        // Version = next number for same vehicle+type
        var existing = await _repo.FindAsync(d => d.VehicleId == vehicleId && d.DocumentType == documentType && !d.IsDeleted);
        var version = existing.Any() ? existing.Max(d => d.Version) + 1 : 1;

        // Save to disk: uploads/{vehicleId}/{type}_v{version}{ext}
        var vehicleDir = Path.Combine(_basePath, vehicleId.ToString());
        Directory.CreateDirectory(vehicleDir);
        var safeType = string.Join("_", documentType.Split(Path.GetInvalidFileNameChars()));
        var storedName = $"{safeType}_v{version}_{Guid.NewGuid():N}{ext}";
        var fullPath = Path.Combine(vehicleDir, storedName);
        await File.WriteAllBytesAsync(fullPath, content);

        var doc = new VehicleDocument
        {
            VehicleId    = vehicleId,
            Category     = category,
            DocumentType = documentType,
            FileName     = fileName,
            FilePath     = Path.Combine(vehicleId.ToString(), storedName),  // relative
            FileSize     = content.Length,
            ContentType  = contentType,
            Version      = version,
            UploadedBy   = userId
        };
        await _repo.AddAsync(doc);
        await _repo.SaveChangesAsync();
        return (true, string.Empty, Map(doc));
    }

    public async Task<(byte[] Content, string ContentType, string FileName)?> DownloadAsync(int id)
    {
        var doc = await _repo.GetByIdAsync(id);
        if (doc is null || doc.IsDeleted) return null;

        var fullPath = Path.Combine(_basePath, doc.FilePath);
        if (!File.Exists(fullPath)) return null;

        var bytes = await File.ReadAllBytesAsync(fullPath);
        return (bytes, doc.ContentType, doc.FileName);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var doc = await _repo.GetByIdAsync(id);
        if (doc is null) return false;
        doc.IsDeleted = true;
        doc.UpdatedAt = DateTime.UtcNow;
        _repo.Update(doc);
        await _repo.SaveChangesAsync();
        return true;
    }

    private static VehicleDocumentDto Map(VehicleDocument d) => new()
    {
        Id = d.Id, VehicleId = d.VehicleId, Category = d.Category, DocumentType = d.DocumentType,
        FileName = d.FileName, FileSize = d.FileSize, ContentType = d.ContentType,
        Version = d.Version, CreatedAt = d.CreatedAt
    };
}
