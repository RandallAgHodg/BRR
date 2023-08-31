using BRR.Contracts.Responses.Houses;
using BRR.Domain.Entities;

namespace BRR.Domain.Repositories;

public interface IHouseRepository
{
    public Task AddAsync(House house);

    public Task<House?> FindByIdAsync(int houseId);

    public Task<IEnumerable<House>> GetTop5HousesByDiscountAsync();
    public Task<IEnumerable<House>> SearchHousesAsync(SearchHousesFilter filter);
}

public sealed record SearchHousesFilter(
        string querySearch,
        int price,
        int livingrooms,
        int floors,
        int bathrooms,
        bool hasBalcony,
        bool hasDiscount,
        bool hasPool
    );