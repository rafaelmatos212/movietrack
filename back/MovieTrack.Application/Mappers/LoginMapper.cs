using MovieTrack.Application.RequestsResponse.Login;

namespace MovieTrack.Application.Mappers
{
    public class LoginMapper
    {
        public static LoginResponse ToResponse(string token)
        {
            return new LoginResponse { Token = token };
        }
    }
}
