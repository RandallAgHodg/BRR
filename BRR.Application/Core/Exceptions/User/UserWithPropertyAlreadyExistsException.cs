using FluentValidation;

namespace BRR.Application.Core.Exceptions.User;

public sealed class UserWithPropertyAlreadyExistsException : ValidationException
{
    public UserWithPropertyAlreadyExistsException(string message) : base(message)
    {
    }
}
