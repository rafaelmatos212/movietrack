using static BCrypt.Net.BCrypt;

namespace MovieTrack.Application.Security
{
    public static class PasswordHasher
    {
        private const int DefaultWorkFactor = 12;

        public static string Hash(string password, int workFactor = DefaultWorkFactor)
        {
            return HashPassword(password, workFactor);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return Verify(password, hashedPassword);
        }
    }
}
