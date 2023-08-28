using BRR.Application.Abstractions.Messaging;
using BRR.Contracts.Responses.Users;

namespace BRR.Application.Users.Queries.GetUserById;

public sealed record GetUserByIdQuery (int Id): IQuery<UserReponse>;
