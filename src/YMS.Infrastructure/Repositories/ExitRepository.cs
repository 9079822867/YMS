using Microsoft.EntityFrameworkCore;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;
using YMS.Infrastructure.Data;

namespace YMS.Infrastructure.Repositories;

public class ExitRepository : Repository<VehicleExitRequest>, IExitRepository
{
    public ExitRepository(YmsDbContext context) : base(context) { }

    public async Task<IEnumerable<VehicleExitRequest>> GetAllWithDetailsAsync(string? status)
    {
        var query = _dbSet
            .Include(e => e.Vehicle).ThenInclude(v => v.Client)
            .Include(e => e.Vehicle).ThenInclude(v => v.Yard)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(status))
            query = query.Where(e => e.Status == status);

        return await query.OrderByDescending(e => e.CreatedAt).ToListAsync();
    }

    public async Task<VehicleExitRequest?> GetByIdWithDetailsAsync(int id)
        => await _dbSet
            .Include(e => e.Vehicle).ThenInclude(v => v.Client)
            .Include(e => e.Vehicle).ThenInclude(v => v.Yard)
            .FirstOrDefaultAsync(e => e.Id == id);

    public async Task<bool> HasOpenRequestAsync(int vehicleId)
        => await _dbSet.AnyAsync(e =>
            e.VehicleId == vehicleId &&
            (e.Status == ExitStatus.Pending || e.Status == ExitStatus.Approved));
}
