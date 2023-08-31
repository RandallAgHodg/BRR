using BRR.Application.Abstractions.Messaging;
using BRR.Application.Mapping;
using BRR.Contracts.Responses.Houses;
using BRR.Domain.Repositories;

namespace BRR.Application.Houses.Queries.GetTop5Houses;

public sealed class GetTop5HousesByDiscountQueryHandler : IQueryHandler<GetTop5HousesByDiscountQuery, IEnumerable<HouseResponse>>
{
    private readonly IHouseRepository _houseRepository;

    public GetTop5HousesByDiscountQueryHandler(IHouseRepository houseRepository) =>
        _houseRepository = houseRepository;
    

    public async Task<IEnumerable<HouseResponse>> Handle(GetTop5HousesByDiscountQuery request, CancellationToken cancellationToken)
    {
        var houses = await _houseRepository.GetTop5HousesByDiscountAsync();

        var response = houses.Select(x => x.ToHouseResponse());

        return response;
    }
}
