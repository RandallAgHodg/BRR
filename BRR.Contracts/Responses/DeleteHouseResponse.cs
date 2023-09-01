using BRR.Contracts.Responses.Houses;

namespace BRR.Contracts.Responses;

public sealed record DeleteHouseResponse : RejectHouseResponse
{
    public DeleteHouseResponse(string message): base(message)
    {
    }
}
