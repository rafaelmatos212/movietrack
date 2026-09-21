using MovieTrack.Application.DTOs;

namespace MovieTrack.Application.Interfaces
{
    public interface IAccountService
    {
        Task<UserDTO> Register(RegisterDTO dto);
        Task<string> Login(string email, string password);
    }
}
