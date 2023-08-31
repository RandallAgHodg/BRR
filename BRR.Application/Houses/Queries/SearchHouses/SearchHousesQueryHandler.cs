using BRR.Application.Abstractions.Messaging;
using BRR.Application.Mapping;
using BRR.Contracts.Responses.Houses;
using BRR.Domain.Repositories;

namespace BRR.Application.Houses.Queries.SearchHouses;

public sealed class SearchHousesQueryHandler : IQueryHandler<SearchHousesQuery, IEnumerable<HouseResponse>>
{
    private readonly IHouseRepository _houseRepository;

    public SearchHousesQueryHandler(IHouseRepository houseRepository) =>
        _houseRepository = houseRepository;
    

    public async Task<IEnumerable<HouseResponse>> Handle(SearchHousesQuery request, CancellationToken cancellationToken)
    {
        var filter = new SearchHousesFilter(request.querySearch, request.price, request.livingrooms,
            request.floors, request.bathrooms, request.hasBalcony, request.hasDiscount, request.hasPool);

        var houses = await _houseRepository.SearchHousesAsync(filter);

        var response = houses.Select(x => x.ToHouseResponse());

        return response;
    }
}
