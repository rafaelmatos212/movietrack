namespace MovieTrack.Application.RequestsResponse.Register
{
    public class RegisterUserResponse
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
