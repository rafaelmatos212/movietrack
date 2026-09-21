namespace MovieTrack.Domain.Exceptions
{
    public class InvalidEmailException : DomainException
    {
        public InvalidEmailException(string email) : base($"O e-mail '{email}' é inválido") { }

        public InvalidEmailException() : base("O email fornecido é inválido.") { }
    }
}
