using BRR.Domain.Entities;

namespace BRR.Domain.Repositories;

public interface IClientRepository
{
    public Task<Client> FindByEmailAsync(string Email);
    public Task<Client> FindByIdAsync(int id);
    public Task<Client> LoginAsync(string email, string password);
    public Task CreateClientAsync(Client client);

}
