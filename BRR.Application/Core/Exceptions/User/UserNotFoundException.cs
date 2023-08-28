using BRR.Domain.Primitives.Exceptions;

namespace BRR.Application.Core.Exceptions.User;

public sealed class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(string message) : base(message)
    {
    }
}
