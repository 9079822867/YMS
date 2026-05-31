using YMS.Domain.Entities;

namespace YMS.Domain.Interfaces;

public interface ITransferRepository : IRepository<VehicleTransfer>
{
    Task<IEnumerable<VehicleTransfer>> GetAllWithDetailsAsync(string? status);
    Task<IEnumerable<VehicleTransfer>> GetHistoryAsync(int vehicleId);
    Task<bool> HasOpenAsync(int vehicleId);
}

public interface IInspectionRepository : IRepository<Inspection>
{
    Task<IEnumerable<Inspection>> GetAllWithDetailsAsync(string? status);
}

public interface IAuctionRepository : IRepository<Auction>
{
    Task<IEnumerable<Auction>> GetAllWithDetailsAsync(string? status);
}
