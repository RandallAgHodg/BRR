using BRR.Application.Core.Extensions;
using FluentValidation;

namespace BRR.Application.Houses.Commands.RejectHouseProposal;

public sealed class RejectHouseProposalCommandValidator : AbstractValidator<RejectHouseProposalCommand>
{
    public RejectHouseProposalCommandValidator() =>
        RuleFor(x => x.houseId)
            .IsRequired("id casa");
    
}
