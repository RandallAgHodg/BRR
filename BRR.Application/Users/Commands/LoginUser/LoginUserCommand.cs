using BRR.Application.Abstractions.Messaging;
using BRR.Contracts.Responses.Users;

namespace BRR.Application.Users.Commands.LoginUser;

public sealed record LoginUserCommand (string email, string password) : ICommand<AuthResponse>;
