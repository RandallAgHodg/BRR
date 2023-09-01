using BRR.Contracts.Requests.Houses;

namespace BRR.WebAPI.Requests;

public class UpdateHouseInformationRequest : UpdateHouseRequest
{
    public IFormFile Picture { get; init; }
    public IFormFile Video { get; init; }
}
