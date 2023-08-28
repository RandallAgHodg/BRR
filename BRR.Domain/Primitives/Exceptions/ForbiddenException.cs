namespace BRR.Domain.Primitives.Exceptions;

public abstract class ForbiddenException : Exception
{
    public ForbiddenException(string message) : base(message)
    {
        
    }
}
