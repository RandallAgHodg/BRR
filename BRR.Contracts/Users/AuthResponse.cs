namespace BRR.Contracts.Users;

public sealed record AuthResponse 
    (string token, UserReponse user);