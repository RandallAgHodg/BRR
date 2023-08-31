using BRR.Application.Abstractions.Messaging;
using BRR.Contracts.Responses.Users;

namespace BRR.Application.Users.Queries.RefreshToken;

public sealed record RefreshTokenQuery : IQuery<AuthResponse>;
