using BRR.Domain.Entities;
using BRR.Domain.Repositories;
using BRR.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BRR.Infrastructure.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly BRRDbContext _context;

    public UserRepository(BRRDbContext context)
    {
        _context = context;
    }

    public async Task<AppUser> FindByEmailAsync(string email) =>
        await _context.Set<AppUser>().FirstOrDefaultAsync(x => x.Email == email);
}
