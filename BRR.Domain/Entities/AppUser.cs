using BRR.Contracts.Users;
using Microsoft.AspNetCore.Identity;

namespace BRR.Domain.Entities;

public class AppUser : IdentityUser<int>
{
    private AppUser(): base() { }

    public static AppUser Create(string firstName, string secondName, string lastName, string secondLastName, string email, string password, int age, string phonenumber,  string gender)
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
            Gender = gender
        };
    }

    public static implicit operator UserReponse(AppUser user)
    {
        return new UserReponse(user.Id, user.FirstName, 
            user.SecondName, user.LastName, 
            user.SecondLastName, user.Email, 
            user.Password, user.Age, 
            user.PhoneNumber, user.Gender);
    }

    public int Id { get; init; }
    public string FirstName { get; private set; }
    public string SecondName { get; private set; }
    public string LastName { get; private set; }
    public string SecondLastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public int Age { get; private set; }
    public string PhoneNumber { get; private set; }
    public string PictureUrl { get; private set; }
    public string Gender { get; private set; }
    private HashSet<AppUser> _clients { get; set; } = new();
    public IReadOnlyCollection<AppUser> Clients => _clients.ToList();
    public bool deleted { get; set; }
}
