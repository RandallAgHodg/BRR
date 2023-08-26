namespace BRR.Contracts.Users;

public sealed record UserRequest(string FirstName,
    string SecondName,
    string LastName,
    string SecondLastName,
    string Email,
    string Password,
    int Age,
    string PhoneNumber,
    string Gender, string Role);