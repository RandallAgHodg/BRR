using BRR.Contracts.Responses.Users;
using BRR.Domain.Entities;

namespace BRR.Application.Mapping;

public static class MessageToApiContract
{
    public static UserReponse ToUserResponse(this AppUser user) =>
        new UserReponse(user.Id, user.FirstName, user.SecondName,
            user.LastName, user.SecondLastName, user.Email,
             user.Age, user.PhoneNumber, user.Gender, user.PictureUrl);   
    public static UserWithClientsResponse ToUserWithClientsResponse(this AppUser user) =>
        new UserWithClientsResponse(user.ToUserResponse(), user.Clients?.Select(x => x?.ToUserResponse()));
}
