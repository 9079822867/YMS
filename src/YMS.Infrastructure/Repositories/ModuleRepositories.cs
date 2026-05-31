using Microsoft.EntityFrameworkCore;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;
using YMS.Infrastructure.Data;

namespace YMS.Infrastructure.Repositories;

public class TransferRepository : Repository<VehicleTransfer>, ITransferRepository
{
    public TransferRepository(YmsDbContext ctx) : base(ctx) { }

    public async Task<IEnumerable<VehicleTransfer>> GetAllWithDetailsAsync(string? status)
    {
        var q = _dbSet.Include(t => t.Vehicle)
                      .Include(t => t.FromYard)
                      .Include(t => t.ToYard)
                      .AsQueryable();
        if (!string.IsNullOrWhiteSpace(status)) q = q.Where(t => t.Status == status);
        return await q.OrderByDescending(t => t.CreatedAt).ToListAsync();
    }

    public async Task<IEnumerable<VehicleTransfer>> GetHistoryAsync(int vehicleId)
        => await _dbSet.Include(t => t.FromYard).Include(t => t.ToYard).Include(t => t.Vehicle)
                       .Where(t => t.VehicleId == vehicleId)
                       .OrderByDescending(t => t.CreatedAt).ToListAsync();

    public async Task<bool> HasOpenAsync(int vehicleId)
        => await _dbSet.AnyAsync(t => t.VehicleId == vehicleId &&
            (t.Status == TransferStatus.Requested || t.Status == TransferStatus.Approved || t.Status == TransferStatus.Dispatched));
}

public class InspectionRepository : Repository<Inspection>, IInspectionRepository
{
    public InspectionRepository(YmsDbContext ctx) : base(ctx) { }

    public async Task<IEnumerable<Inspection>> GetAllWithDetailsAsync(string? status)
    {
        var q = _dbSet.Include(i => i.Vehicle).ThenInclude(v => v.Client).AsQueryable();
        if (!string.IsNullOrWhiteSpace(status)) q = q.Where(i => i.Status == status);
        return await q.OrderByDescending(i => i.CreatedAt).ToListAsync();
    }
}

public class AuctionRepository : Repository<Auction>, IAuctionRepository
{
    public AuctionRepository(YmsDbContext ctx) : base(ctx) { }

    public async Task<IEnumerable<Auction>> GetAllWithDetailsAsync(string? status)
    {
        var q = _dbSet.Include(a => a.Vehicle).ThenInclude(v => v.Client).AsQueryable();
        if (!string.IsNullOrWhiteSpace(status)) q = q.Where(a => a.Status == status);
        return await q.OrderByDescending(a => a.CreatedAt).ToListAsync();
    }
}
