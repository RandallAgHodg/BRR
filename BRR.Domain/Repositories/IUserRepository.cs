using BRR.Domain.Entities;

namespace BRR.Domain.Repositories;

public interface IUserRepository
{
    public Task<AppUser> FindByEmailAsync(string email);
}
