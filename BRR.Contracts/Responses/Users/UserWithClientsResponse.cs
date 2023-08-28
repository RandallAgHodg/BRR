using Microsoft.VisualBasic;

namespace BRR.Contracts.Responses.Users;

public sealed record UserWithClientsResponse : UserReponse
{
    public IEnumerable<UserReponse> Clients { get; init; } = Enumerable.Empty<UserReponse>();
    public UserWithClientsResponse(UserReponse userReponse, IEnumerable<UserReponse> clients) 
        : base(userReponse) =>
        Clients = clients;
}