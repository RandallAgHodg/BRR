namespace BRR.Contracts.Responses.Users;

public record UserReponse(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string PictureUrl,
    string Role);

