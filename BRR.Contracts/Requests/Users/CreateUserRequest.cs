namespace BRR.Contracts.Requests.Users;

public class CreateUserRequest {

    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string LastName { get; set; }
    public string SecondLastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int Age { get; set; }
    public string PhoneNumber { get; set; }
    public string Gender { get; set; }
    public string Role { get; set; }
}