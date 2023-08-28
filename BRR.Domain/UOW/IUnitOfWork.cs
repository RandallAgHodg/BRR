namespace BRR.Domain.UOW;

public interface IUnitOfWork
{
    public Task<int> SaveChangesAsync();
}
