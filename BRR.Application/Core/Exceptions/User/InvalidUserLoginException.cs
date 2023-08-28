using FluentValidation;

namespace BRR.Application.Core.Exceptions.User;

public sealed class InvalidUserLoginException : ValidationException
{
    public InvalidUserLoginException(string message) : base(message)
    {
        
    }
}
