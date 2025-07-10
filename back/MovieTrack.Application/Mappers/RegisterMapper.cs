using MovieTrack.Application.DTOs;
using MovieTrack.Application.RequestsResponse.Register;
using MovieTrack.Domain.Entities;

namespace MovieTrack.Application.Mappers
{
    public class RegisterMapper
    {
        public static RegisterDTO ToDto(RegisterUserRequest request)
        {
            return new RegisterDTO
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password
            };
        }

        public static User ToEntity(RegisterDTO dto)
        {
            return new User(dto.Name, dto.Email, dto.Password);
        }

        public static RegisterUserResponse ToResponse(User user)
        {
            return new RegisterUserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}
