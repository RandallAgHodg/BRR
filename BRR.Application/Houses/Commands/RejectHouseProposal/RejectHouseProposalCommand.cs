using BRR.Application.Abstractions.Messaging;
using BRR.Contracts.Responses.Houses;

namespace BRR.Application.Houses.Commands.RejectHouseProposal;

public sealed record RejectHouseProposalCommand(int houseId) : ICommand<RejectHouseResponse>;
