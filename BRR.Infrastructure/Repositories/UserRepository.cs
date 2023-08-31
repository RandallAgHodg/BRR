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

    public async Task AddClient(int userId, int ClientId)
    {
        await _context.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO Agentes_Clientes VALUES ({userId}, {ClientId})");
    }

    public Task<bool> CheckValidLoginAsync(string email, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<AppUser> FindByEmailAsync(string email) =>
        await _context.Set<AppUser>().FirstOrDefaultAsync(x => x.Email == email);

    public async Task<AppUser> FindByIdAsync(int id) =>
        await _context
        .Set<AppUser>()
        .FirstOrDefaultAsync(x => x.Id == id);  

    public async Task<IEnumerable<AppUser>> GetAgentClientsAsync(int AgentId) =>
        await _context
        .Set<AppUser>()
        .Where(x => x.AgentId == AgentId)
        .ToListAsync();

    public async Task<AppUser> GetClientAgentAsync(int clientId)
    {
        throw new NotImplementedException();

    }
}
