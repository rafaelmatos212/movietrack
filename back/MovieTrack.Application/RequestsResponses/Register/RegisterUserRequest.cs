namespace MovieTrack.Application.RequestsResponse.Register
{
    public class RegisterUserRequest
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
