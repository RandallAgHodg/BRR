using BRR.Domain.Primitives.Exceptions;

namespace BRR.Application.Core.Exceptions.User;

public sealed class CantAddYourselfAsAClientException : ForbiddenException
{
    public CantAddYourselfAsAClientException() : 
        base("No puedes agregarte a ti mismo como cliente.")
    {
        
    }
}
