using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;

namespace BRR.Domain.Entities;

public sealed class Account : IdentityUser<int>
{
    private HashSet<Agent> _agents { get; set; } = new();
    private HashSet<Client> _clients{ get; set; } = new();
    private Account()
    {
        
    }

    private Account(string firstName, string lastName, string email, string phoneNumber, string pictureUrl, Role role)
    {
        FirstName = firstName;
        LastName = lastName;
        PictureUrl = pictureUrl;
        UserName = email;
        Email = email;
        PhoneNumber = phoneNumber;
        RoleId = role.Id;
        Token = $"{Guid.NewGuid()}{DateTime.UtcNow}";
        IsConfirmed = false;
        IsDeleted = false;
    }
    public void AddAgent() => _agents.Add(Agent.Create(this));
    public static Account Create(string firstName, string lastName, string email, string phoneNumber, string pictureUrl, Role role) =>
        new Account(firstName, lastName, email, phoneNumber, pictureUrl, role);

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string PictureUrl { get; private set; }
    public int RoleId { get; private set; }
    public Role Role { get; set; }
    public bool IsDeleted { get; private set; }
    public string Token { get; private set; }
    public bool IsConfirmed { get; private set; }
    public IReadOnlyCollection<Agent> Agents => _agents.ToList();
    public IReadOnlyCollection<Client> Clients => _clients.ToList();
}
