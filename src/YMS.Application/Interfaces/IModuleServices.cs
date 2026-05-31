using YMS.Application.DTOs;

namespace YMS.Application.Interfaces;

public interface ITransferService
{
    Task<IEnumerable<TransferListDto>> GetAllAsync(string? status);
    Task<IEnumerable<TransferListDto>> GetHistoryAsync(int vehicleId);
    Task<(bool Success, string Error, int Id)> CreateAsync(CreateTransferRequest request, int userId);
    Task<(bool Success, string Error)> ApproveAsync(int id, bool approve, string? reason, int approverId);
    Task<(bool Success, string Error)> DispatchAsync(int id);
    Task<(bool Success, string Error)> ReceiveAsync(int id);
    Task<bool> CancelAsync(int id);
}

public interface IInspectionService
{
    Task<IEnumerable<InspectionListDto>> GetAllAsync(string? status);
    Task<(bool Success, string Error, int Id)> CreateAsync(CreateInspectionRequest request, int userId);
    Task<(bool Success, string Error)> ScheduleAsync(int id, DateTime date, string? agency);
    Task<(bool Success, string Error)> CompleteAsync(int id, CompleteInspectionRequest request);
    Task<bool> CancelAsync(int id);
}

public interface IAuctionService
{
    Task<IEnumerable<AuctionListDto>> GetAllAsync(string? status);
    Task<(bool Success, string Error, int Id)> CreateAsync(CreateAuctionRequest request, int userId);
    Task<(bool Success, string Error)> RecordBidAsync(int id, decimal bid);
    Task<(bool Success, string Error)> CompleteSaleAsync(int id, CompleteSaleRequest request);
    Task<(bool Success, string Error)> MarkUnsoldAsync(int id);
    Task<bool> CancelAsync(int id);
}

public interface IDocumentService
{
    Task<IEnumerable<VehicleDocumentDto>> GetForVehicleAsync(int vehicleId);
    Task<(bool Success, string Error, VehicleDocumentDto? Doc)> UploadAsync(
        int vehicleId, string category, string documentType, string fileName,
        string contentType, byte[] content, int userId);
    Task<(byte[] Content, string ContentType, string FileName)?> DownloadAsync(int id);
    Task<bool> DeleteAsync(int id);
}

public interface INotificationService
{
    Task<IEnumerable<NotificationDto>> GetForUserAsync(int userId, bool unreadOnly);
    Task<int> GetUnreadCountAsync(int userId);
    Task CreateAsync(int? userId, string title, string message, string type = "Info", string? link = null);
    Task<bool> MarkReadAsync(int id);
    Task MarkAllReadAsync(int userId);
}

public interface IAuditService
{
    Task LogAsync(int userId, string action, string entityType, int? entityId = null, string? details = null, string? ip = null);
    Task<IEnumerable<AuditLogDto>> GetRecentAsync(int take, string? entityType);
}
