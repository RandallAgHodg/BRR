using BRR.Contracts.Requests.Houses;

namespace BRR.WebAPI.Requests;

public sealed class CreateHouseRequest : HouseProposalRequest
{
    public IFormFile Picture { get; set; }
    public IFormFile Video { get; set; }
}
