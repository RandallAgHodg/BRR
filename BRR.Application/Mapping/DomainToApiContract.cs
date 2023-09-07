using BRR.Contracts.Responses.Users;
using BRR.Domain.Entities;

namespace BRR.WebAPI.Mapping;

public static class DomainToApiContract
{
    public static UserReponse ToResponse(this Account account) =>
        new UserReponse(account.Id, account.FirstName, account.LastName, account.Email, account.PhoneNumber, account.PictureUrl, account.Role.Name);

}
