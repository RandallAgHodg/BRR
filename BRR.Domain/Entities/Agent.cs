using Microsoft.AspNetCore.Identity;

namespace BRR.Domain.Entities;

public sealed class Agent
{
    private HashSet<Client> _clients { get; set; } = new();
    private HashSet<Meeting> _meetings { get; set; } = new();   
    private Agent()
    {
        
    }

    private Agent(Account account)
    {
        AccountId = account.Id;
        Account = account;
    }

    
    public static Agent Create(Account account) => new Agent(account);
    public int Id { get; set; }
    public int? AccountId { get; private set; }
    public Account Account { get; set; }
    public IReadOnlyCollection<Client> Clients => _clients.ToList();
    public IReadOnlyCollection<Meeting> Meetings => _meetings.ToList();
}
