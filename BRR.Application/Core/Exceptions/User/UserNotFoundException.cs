namespace BRR.Application.Core.Exceptions.User;

public sealed class UserNotFoundException : Exception
{
    public UserNotFoundException(string message) : base(message)
    {
    }
}
