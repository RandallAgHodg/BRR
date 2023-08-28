namespace BRR.Contracts.Responses.Users;

public sealed record AuthResponse
    (string token, UserReponse user);