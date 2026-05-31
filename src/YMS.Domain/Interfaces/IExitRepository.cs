using YMS.Domain.Entities;

namespace YMS.Domain.Interfaces;

public interface IExitRepository : IRepository<VehicleExitRequest>
{
    Task<IEnumerable<VehicleExitRequest>> GetAllWithDetailsAsync(string? status);
    Task<VehicleExitRequest?> GetByIdWithDetailsAsync(int id);
    Task<bool> HasOpenRequestAsync(int vehicleId);
}
