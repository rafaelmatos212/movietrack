using MovieTrack.Domain.Exceptions;

namespace MovieTrack.Domain.ValueObjects
{
    public class Email
    {
        public string Address { get; private set; } = null!;

        private Email() { }

        public Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new InvalidEmailException(email);

            Address = email;
        }
    }
}
