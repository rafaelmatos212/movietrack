using MovieTrack.Domain.Entities;

namespace MovieTrack.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
