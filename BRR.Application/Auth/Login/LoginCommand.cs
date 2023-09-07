using BRR.Application.Abstractions.Messaging;
using BRR.Contracts.Responses.Users;

namespace BRR.Application.Auth.Login;

public sealed record LoginCommand (string Email, string Password, string Role) : ICommand<AuthResponse>;
