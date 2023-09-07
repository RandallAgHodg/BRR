using FluentValidation;

namespace BRR.Application.Core.Exceptions.User;

public sealed class InvalidRegisterAttemptException : ValidationException
{
    public InvalidRegisterAttemptException(): base("No se pudo registrar el usuario. Intentelo nuevamente.")
    {
        
    }
}
