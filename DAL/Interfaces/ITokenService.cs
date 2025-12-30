using Domain.Entities;

namespace DAL.Interfaces;

public interface ITokenService
{
    public Task<string> CreateToken(User user);
    public string GenerateRefreshToken();
}
