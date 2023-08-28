using Microsoft.AspNetCore.Identity;

namespace BRR.Domain.Entities;

public class AppUser : IdentityUser<int>
{
    private AppUser() { }

    public static AppUser Create(string firstName, string secondName, string lastName, string secondLastName, string email, string password, int age, string phonenumber, string gender, string pictureURL)
    {
        return new AppUser()
        {
            FirstName = firstName,
            SecondName = secondName,
            LastName = lastName,
            SecondLastName = secondLastName,
            Email = email,
            Password = password,
            Age = age,
            PhoneNumber = phonenumber,
            Gender = gender,
            UserName = email,
            PictureUrl = pictureURL
        };
    }

    public static IEnumerable<AppUser> PopulateDatabase() =>
        new List<AppUser>{ new AppUser()
        {
            Id = 1,
            FirstName = "Agente",
            SecondName = "string",
            LastName = "string",
            SecondLastName = "string",
            Email = "agente@correo.com",
            Password = "string",
            Age = 30,
            PhoneNumber = "string",
            Gender= "M",
            UserName = "agente@correo.com",
            NormalizedEmail = StringNormalizationExtensions.Normalize("agente@correo.com"),
            NormalizedUserName = StringNormalizationExtensions.Normalize("agente@correo.com")
        }, 
            new AppUser()
        {
            Id = 2,
            FirstName = "Cliente",
            SecondName = "string",
            LastName = "string",
            SecondLastName = "string",
            Email = "cliente@correo.com",
            Password = "string",
            Age = 20,
            PhoneNumber = "string",
            Gender= "F",
            UserName = "cliente@correo.com",
            AgentId = 1,
            NormalizedEmail = StringNormalizationExtensions.Normalize("cliente@correo.com"),
            NormalizedUserName = StringNormalizationExtensions.Normalize("cliente@correo.com"),
        }  };

    public void SetClients(IEnumerable<AppUser> clients) => _clients.UnionWith(clients);

    public void AddClient(AppUser client) => _clients.Add(client);

    public void SetAgent(AppUser agent) {
        Agent = agent;
        agent.AddClient(this);
    }
  
    public string FirstName { get; private set; }
    public string SecondName { get; private set; }
    public string LastName { get; private set; }
    public string SecondLastName { get; private set; }
    public override string? Email { get; set; }
    public string Password { get; private set; }
    public int Age { get; private set; }
    public string PhoneNumber { get; private set; }
    public string PictureUrl { get; private set; }
    public string Gender { get; private set; }
    public IReadOnlyCollection<AppUser> Clients => _clients.ToList();
    private HashSet<AppUser> _clients { get; set; } = new();
    public AppUser Agent { get; private set; }
    public int? AgentId { get; private set; }
    public bool IsAgent { get; private set; }
    public bool deleted { get; set; }
}
