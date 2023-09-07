namespace BRR.Domain.Entities;

public sealed class Client
{
    private HashSet<House> _houses { get; set; } = new();
    private HashSet<Meeting> _meetings { get; set; } = new();

    private Client()
    {
        
    }
    public int Id { get; private set; }
    public int AccountId { get; private set; }
    public Account Account { get; set; }
    public int? AgentId { get; private set; }
    public Agent Agent { get; private set; }
    public IReadOnlyCollection<House> Houses => _houses.ToList();
    public IReadOnlyCollection<Meeting> Meetings => _meetings.ToList();
}
