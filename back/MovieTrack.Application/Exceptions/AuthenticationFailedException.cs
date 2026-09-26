namespace MovieTrack.Application.Exceptions;

public sealed class AuthenticationFailedException : AppException
{
    public const string DefaultMessage = "E-mail ou senha inválidos.";

    public AuthenticationFailedException() : base(DefaultMessage) { }
}