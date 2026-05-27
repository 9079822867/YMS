using YMS.Domain.Entities;

namespace YMS.Application.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
}
