using BRR.Domain.Entities;
using BRR.Domain.Repositories;
using BRR.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BRR.Infrastructure.Repositories;

public sealed class MeetingRepository : IMeetingRepository
{
    private readonly BRRDbContext _context;

    public MeetingRepository(BRRDbContext context) =>
        _context = context;


    public async Task AddAsync(Meeting meeting) =>
        await _context.AddAsync(meeting);

    public async Task<Meeting> FindByIdAsync(int houseId, int userId) =>
        await _context
        .Set<Meeting>()
        .FirstOrDefaultAsync(
            x => 
            (x.HouseId == houseId && x.ClientId == userId) 
            || (x.HouseId == houseId && x.AgentId == userId));

    public async Task<IEnumerable<Meeting>> GetAgentMeetings(int userId) =>
        await _context
        .Set<Meeting>()
        .Where(x => x.AgentId == userId)
        .ToListAsync();

    public async Task<IEnumerable<Meeting>> GetClientMeetings(int userId) =>
        await _context
        .Set<Meeting>()
        .Where(x => x.ClientId == userId)
        .ToListAsync();
}
