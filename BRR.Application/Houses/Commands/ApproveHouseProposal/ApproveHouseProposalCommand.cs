using BRR.Application.Abstractions.Messaging;
using BRR.Contracts.Responses.Houses;

namespace BRR.Application.Houses.Commands.ApproveHouseProposal;

public sealed record ApproveHouseProposalCommand (int houseId, int clientId): ICommand<HouseResponseWithAgent>;
