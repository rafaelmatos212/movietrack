using MovieTrack.Application.DTOs;
using MovieTrack.Application.Exceptions;
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
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
            if (existingUser is not null)
                throw new ConflictException("Não foi possível concluir o cadastro com os dados informados.");

            dto.Password = PasswordHasher.Hash(dto.Password);

            var user = RegisterMapper.ToEntity(dto);
            var createdUser = await _userRepository.AddAsync(user);
            return RegisterMapper.ToUserDto(createdUser);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user is null || !PasswordHasher.VerifyPassword(password, user.PasswordHash))
                throw new AuthenticationFailedException();

            return _tokenService.GenerateToken(user);
        }
    }
}
