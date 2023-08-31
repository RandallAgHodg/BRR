namespace BRR.Domain.Primitives.Exceptions;

public abstract class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }
}
