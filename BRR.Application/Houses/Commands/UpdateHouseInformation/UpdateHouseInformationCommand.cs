using BRR.Application.Houses.Commands.SendHouseProposal;
using CloudinaryDotNet.Actions;

namespace BRR.Application.Houses.Commands.UpdateHouseInformation;

public sealed record UpdateHouseInformationCommand : SendHouseProposalCommand
{
    public UpdateHouseInformationCommand(int id, string title, string address, decimal area, decimal price
        , int discount, int bedrooms, int bathrooms, int livingrooms, int floors,
        ImageUploadParams Picture, VideoUploadParams Video, bool hasPool = false, 
        bool hasBalcony = false) : base(title, address, area, price, discount, bedrooms, bathrooms, livingrooms, floors, Picture, Video, hasPool, hasBalcony)
    {
        Id = id;
    }

    public int Id { get; init; }
}
