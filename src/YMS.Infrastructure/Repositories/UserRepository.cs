using Microsoft.EntityFrameworkCore;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;
using YMS.Infrastructure.Data;

namespace YMS.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(YmsDbContext context) : base(context) { }

    public async Task<User?> GetByEmailAsync(string email)
        => await _dbSet.FirstOrDefaultAsync(u => u.Email == email && u.IsActive);
}
