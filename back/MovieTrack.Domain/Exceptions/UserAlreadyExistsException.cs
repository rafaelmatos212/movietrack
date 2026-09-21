namespace MovieTrack.Domain.Exceptions
{
    public class UserAlreadyExistsException : DomainException
    {
        public UserAlreadyExistsException(string email) : base($"Já existe um usuário cadastrado com o e-mail '{email}'") { }
    }
}
