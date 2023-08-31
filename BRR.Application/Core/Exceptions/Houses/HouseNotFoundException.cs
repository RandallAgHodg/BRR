using BRR.Domain.Primitives.Exceptions;

namespace BRR.Application.Core.Exceptions.Houses;

public sealed class HouseNotFoundException : NotFoundException
{
    public HouseNotFoundException(string message) : base(message)
    {
    }
}
