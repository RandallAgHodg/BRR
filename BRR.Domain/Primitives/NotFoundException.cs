namespace BRR.Domain.Primitives;

public class NotFoundException : Exception
{
    public NotFoundException(string message): base(message)
    {
    }
}
