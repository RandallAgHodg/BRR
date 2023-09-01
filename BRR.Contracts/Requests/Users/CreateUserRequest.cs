namespace BRR.Contracts.Requests.Users;

public class CreateUserRequest {

    public string FirstName { get; init; }
    public string SecondName { get; init; }
    public string LastName { get; init; }
    public string SecondLastName { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public int Age { get; init; }
    public string PhoneNumber { get; init; }
    public string Gender { get; init; }
}