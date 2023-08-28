using BRR.Application.Abstractions.Messaging;
using BRR.Contracts.Responses.Users;

namespace BRR.Application.Users.Queries.GetUserProfile;

public sealed class GetUserProfileQuery : IQuery<UserWithClientsResponse> { }
