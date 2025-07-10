using MovieTrack.Application.DTOs;
using MovieTrack.Application.Mappers;
using MovieTrack.Domain.Entities;
using MovieTrack.Domain.Interfaces;
using MovieTrack.Domain.Interfaces.Services;
using static BCrypt.Net.BCrypt;

namespace MovieTrack.Application.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private const int WorkFactor = 12;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Register(RegisterDTO dto)
        {
            try
            {
                if (dto == null)
                    throw new Exception("Dados de registro não podem ser nulos.");

                var userExists = await _userRepository.GetByEmailAsync(dto.Email);
                if (userExists != null)
                    throw new Exception("E-mail já está em uso.");

                dto.Password = HashPassword(dto.Password, WorkFactor);

                var user = RegisterMapper.ToEntity(dto);
                return await _userRepository.AddAsync(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao registrar usuário. Verifique os dados e tente novamente.", ex);
            }

        }
    }
}
