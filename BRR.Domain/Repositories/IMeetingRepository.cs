using BRR.Domain.Entities;

namespace BRR.Domain.Repositories;

public interface IMeetingRepository
{
    public Task<Meeting> FindByIdAsync(int houseId, int userId);
    public Task<IEnumerable<Meeting>> GetClientMeetings(int clientId);
    public Task<IEnumerable<Meeting>> GetAgentMeetings(int agentId);
    public Task AddAsync(Meeting meeting); 
}
