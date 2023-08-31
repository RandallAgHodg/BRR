using BRR.Domain.Entities;

namespace BRR.Domain.Repositories;

public interface IUserRepository
{
    public Task<AppUser?> FindByIdAsync(int Id);
    public Task<IEnumerable<AppUser>> GetAgentClientsAsync(int AgentId);
    public Task<AppUser> FindByEmailAsync(string email);
    public Task<bool> CheckValidLoginAsync(string email, string password);
    public Task AddClient(int UserId, int ClientId);
    public Task<AppUser?> GetClientAgentAsync(int clientId);
}
