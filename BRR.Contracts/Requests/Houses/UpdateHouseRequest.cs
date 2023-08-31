namespace BRR.Contracts.Requests.Houses;

public sealed class UpdateHouseRequest : HouseProposalRequest
{
    public int Id { get; init; }
}
