using BRR.Domain.Primitives.Exceptions;

namespace BRR.Application.Core.Exceptions.User;

public sealed class CouldntRetrieveLoggedUserInformationException : UnauthorizedException
{
    public CouldntRetrieveLoggedUserInformationException(string message) : base(message)
    {
    }
}
