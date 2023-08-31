using BRR.Application.Abstractions.Messaging;
using BRR.Contracts.Responses.Houses;

namespace BRR.Application.Houses.Queries.SearchHouses;

public sealed record SearchHousesQuery (
        string querySearch,
        int price,
        int livingrooms,
        int floors,
        int bathrooms,
        bool hasBalcony, 
        bool hasDiscount,
        bool hasPool
    ) : IQuery<IEnumerable<HouseResponse>>;
