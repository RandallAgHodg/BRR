using BRR.Domain.Entities;
using BRR.Domain.Repositories;
using BRR.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BRR.Infrastructure.Repositories;

public sealed class HouseRepository : IHouseRepository
{
    private readonly BRRDbContext _context;

    public HouseRepository(BRRDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(House house) => await _context.AddAsync(house);

    public async Task<House> FindByIdAsync(int houseId) => 
        await _context.Set<House>().FirstOrDefaultAsync(x => x.Id == houseId);

    public async Task<IEnumerable<House>> GetTop5HousesByDiscountAsync() =>
        await _context
        .Set<House>()
        .OrderByDescending(x => x.Discount)
        .Take(5)
        .ToListAsync();

    public async Task<IEnumerable<House>> SearchHousesAsync(SearchHousesFilter filter)
    {
        var housesQueryable = _context.Set<House>().AsQueryable();

        if (!string.IsNullOrEmpty(filter.querySearch))
            housesQueryable = housesQueryable
                .Where(x => x
                .Title
                .Contains(filter.querySearch));

        if (filter.price is not 0)
            housesQueryable = housesQueryable
                .Where(x => x.Price <= filter.price);

        if(filter.floors is not 0)
            housesQueryable = housesQueryable
                .Where(x => x.Floors == filter.floors);

        if(filter.bathrooms is not 0)
            housesQueryable = housesQueryable
                .Where(x => x.Bathrooms == filter.bathrooms);

        if (filter.hasDiscount)
            housesQueryable = housesQueryable
                .Where(x => x.Discount != 0);

        if (filter.hasPool)
            housesQueryable = housesQueryable
                .Where(x => x.HasPool);

        if (filter.hasBalcony)
            housesQueryable = housesQueryable
                .Where(x => x.HasBalcony);


        var houses = await housesQueryable.ToListAsync();

        return houses;
    }
}
