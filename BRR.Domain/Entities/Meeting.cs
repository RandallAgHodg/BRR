namespace BRR.Domain.Entities;

public sealed class Meeting 
{
    private Meeting(string description, int houseId, int clientId, int agentId, DateTime date)
    {
        Description = description;
        HouseId = houseId;
        ClientId = clientId;
        AgentId = agentId;
        Date = date;
    }

    public static Meeting Create(string description, int houseId, int clientId, int agentId, DateTime date) =>
        new Meeting(description, houseId, clientId, agentId, date); 

    private Meeting(){}

    public string Description { get; set; }
    public int HouseId { get; private set; }
    public int ClientId { get; private set; }
    public int AgentId { get; set; }
    public DateTime Date { get; private set; }
    public House House { get; private set; }
    public Agent Agent { get; private set; }
    public Client Client { get; private set; }
}
