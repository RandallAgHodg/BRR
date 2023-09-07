using BRR.Domain.Entities;
using BRR.Domain.Repositories;
using BRR.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BRR.Infrastructure.Repositories;

public sealed class AgentRepository : IAgentRepository
{
    private readonly BRRDbContext _context;

    public AgentRepository(BRRDbContext context) =>
        _context = context;

    public async Task CreateAgentAsync(Agent agent) => await _context.AddAsync(agent);

    public async Task<Agent> FindByEmailAsync(string Email) =>
        await _context
        .Set<Agent>()
        .FirstOrDefaultAsync(x => x.Account.Email == Email);

    public async Task<Agent> FindByIdAsync(int id) =>
        await _context
        .Set<Agent>()
        .FirstOrDefaultAsync(x => x.Id == id);
}
