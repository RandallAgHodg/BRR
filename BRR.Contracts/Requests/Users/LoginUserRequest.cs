

namespace BRR.Contracts.Requests.Users;

public sealed record LoginUserRequest(string Email, string Password, string Role);
