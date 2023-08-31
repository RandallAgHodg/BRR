using BRR.Contracts.Responses.Houses;

namespace BRR.Contracts.Requests.Houses;

public sealed record SearchHousesFilterRequest(
        string querySearch,
        int price,
        int livingrooms,
        int floors,
        int bathrooms,
        bool hasBalcony,
        bool hasDiscount,
        bool hasPool
    );
