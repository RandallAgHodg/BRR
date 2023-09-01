using BRR.Application.Abstractions.Messaging;
using BRR.Application.Houses.Commands.RejectHouseProposal;
using BRR.Contracts.Responses;

namespace BRR.Application.Houses.Commands.DeleteHouse;

public sealed record DeleteHouseCommand (int houseId): ICommand<DeleteHouseResponse>;
