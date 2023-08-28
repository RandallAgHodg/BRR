namespace BRR.Domain.Entities;

public sealed class AgentsClients
{
    public int AgentId { get; set; }
    public int ClientId { get; set; }
    public ICollection<AppUser> Agents { get; set; }
    public ICollection<AppUser> Clients { get; set; }
}
