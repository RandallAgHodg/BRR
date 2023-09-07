using BRR.Domain.Entities;

namespace BRR.Domain.Repositories;

public interface IAgentRepository
{
    public Task<Agent> FindByEmailAsync(string Email);
    public Task<Agent> FindByIdAsync(int id);
    public Task CreateAgentAsync(Agent agent);
}
