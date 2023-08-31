namespace BRR.Domain.Primitives.Exceptions;

public abstract class UnauthorizedException : Exception
{
    public UnauthorizedException(string message) : base(message)
    {
        
    }
}
