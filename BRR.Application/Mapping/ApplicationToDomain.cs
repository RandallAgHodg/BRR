using BRR.Application.Houses.Commands.UpdateHouseInformation;
using BRR.Domain.Entities;

namespace BRR.Application.Mapping;

public static class ApplicationToDomain
{
    public static House ToDomain(this UpdateHouseCommand command, string pictureUrl, string videoUrl) =>
        House.Create(command.Id, pictureUrl, videoUrl, 
            command.title, command.area, command.address, 
            command.price, command.discount, command.bedrooms, 
            command.bathrooms, command.livingrooms, command.floors, command.hasPool, command.hasBalcony);
}
