using Microsoft.AspNetCore.Identity;

namespace BRR.Domain.Entities;

public sealed class Role : IdentityRole<int>
{
    public Role(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public static Role AgentRole => new Role(1, "Agente");
    public static Role ClientRole => new Role(2, "Cliente");
    public bool IsAgent => Name == "Agente";
    public bool IsClient => Name == "Cliente";
    public static Role[] PopulateDatabase() => new[] { new Role(1, "Agente"), new Role(2, "Cliente") };     
    public int Id { get; private set; }
    public string Name { get; set; }
    public IEnumerable<Account> Accounts{ get; set; }
}
