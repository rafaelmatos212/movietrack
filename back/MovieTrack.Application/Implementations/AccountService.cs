using MovieTrack.Application.DTOs;
using MovieTrack.Application.Interfaces;
using MovieTrack.Application.Mappers;
using MovieTrack.Application.Security;
using MovieTrack.Domain.Interfaces;

namespace MovieTrack.Application.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AccountService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<UserDTO> Register(RegisterDTO dto)
        {
            try
            {
                if (dto == null)
                    throw new Exception("Dados de registro não podem ser nulos.");

                var userExists = await _userRepository.GetByEmailAsync(dto.Email);
                if (userExists != null)
                    throw new Exception("E-mail já está em uso.");

                dto.Password = PasswordHasher.Hash(dto.Password);

                var user = RegisterMapper.ToEntity(dto);
                var createdUser = await _userRepository.AddAsync(user);
                return RegisterMapper.ToUserDto(createdUser);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao registrar usuário. Verifique os dados e tente novamente.", ex);
            }
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null || !PasswordHasher.VerifyPassword(password, user.PasswordHash))
                throw new UnauthorizedAccessException("E-mail ou senha inválidos.");

            return _tokenService.GenerateToken(user);
        }
    }
}
