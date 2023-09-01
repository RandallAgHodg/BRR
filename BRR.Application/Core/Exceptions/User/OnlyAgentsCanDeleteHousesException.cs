using BRR.Domain.Primitives.Exceptions;

namespace BRR.Application.Core.Exceptions.User;

public sealed class OnlyAgentsCanDeleteHousesException : UnauthorizedException
{
    public OnlyAgentsCanDeleteHousesException(string message): base(message)
    {
        
    }
}
