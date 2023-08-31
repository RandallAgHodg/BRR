using BRR.Contracts.Responses.Houses;
using BRR.Contracts.Responses.Users;
using BRR.Domain.Entities;

namespace BRR.Application.Mapping;

public static class DomnainToApiContract
{
    public static UserReponse ToUserResponse(this AppUser user) =>
        new UserReponse(user.Id, user.FirstName, user.SecondName,
            user.LastName, user.SecondLastName, user.Email,
             user.Age, user.PhoneNumber, user.Gender, user.PictureUrl);   
    public static UserWithClientsResponse ToUserWithClientsResponse(this AppUser user) =>
        new UserWithClientsResponse(user.ToUserResponse(), user.Clients?.Select(x => x?.ToUserResponse()));

    public static HouseResponseWithAgent ToHouseResponseWithAgent(this House house, AppUser agent) =>
        new HouseResponseWithAgent(house.Id, house.Title, house.Address, house.Area,
                          house.Price, house.Discount, house.Bedrooms, house.Bathrooms,
                          house.Livingrooms, house.Floors, house.HasPool, house.HasBalcony,
                          house.IsSold, house.IsAccepted, house.PictureUrl, house.VideoUrl, house.Client.ToUserResponse(), agent.ToUserResponse());

    public static HouseResponse ToHouseResponse(this House house) =>
        new HouseResponse(house.Id, house.Title, house.Address, house.Area,
                          house.Price, house.Discount, house.Bedrooms, house.Bathrooms,
                          house.Livingrooms, house.Floors, house.HasPool, house.HasBalcony,
                          house.IsSold, house.IsAccepted, house.PictureUrl, house.VideoUrl, house.Client.ToUserResponse());
}
