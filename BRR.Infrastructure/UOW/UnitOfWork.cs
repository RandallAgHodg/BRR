using BRR.Domain.UOW;
using BRR.Infrastructure.Database;

namespace BRR.Infrastructure.UOW;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly BRRDbContext _context;

    public UnitOfWork(BRRDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
}
