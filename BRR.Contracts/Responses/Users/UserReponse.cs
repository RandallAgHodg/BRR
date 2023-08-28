namespace BRR.Contracts.Responses.Users;

public record UserReponse(
    int Id,
    string FirstName,
    string SecondName,
    string LastName,
    string SecondLastName,
    string Email,
    int Age,
    string PhoneNumber,
    string Gender,
    string PictureUrl);

