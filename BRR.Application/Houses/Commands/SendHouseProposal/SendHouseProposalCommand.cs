using BRR.Application.Abstractions.Messaging;
using BRR.Contracts.Responses.Houses;
using CloudinaryDotNet.Actions;

namespace BRR.Application.Houses.Commands.SendHouseProposal;
public record SendHouseProposalCommand(
    string title,
    string address,
    decimal area,
    decimal price,
    int discount,
    int bedrooms,
    int bathrooms,
    int livingrooms,
    int floors,
    ImageUploadParams Picture,
    VideoUploadParams Video,
    bool hasPool = false,
    bool hasBalcony = false
    ) : ICommand<HouseResponse>;

