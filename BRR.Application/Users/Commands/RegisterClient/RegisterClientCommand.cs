using BRR.Application.Abstractions.Messaging;
using BRR.Contracts.Responses.Users;

namespace BRR.Application.Users.Commands.AddClient;

public sealed record RegisterClientCommand (int clientId): ICommand<UserReponse>;