using MovieTrack.Application.DTOs;
using MovieTrack.Domain.Entities;

namespace MovieTrack.Domain.Interfaces.Services
{
    public interface IAccountService
    {
        Task Login(string email, string password);
        Task<User> Register(RegisterDTO dto);
    }
}
