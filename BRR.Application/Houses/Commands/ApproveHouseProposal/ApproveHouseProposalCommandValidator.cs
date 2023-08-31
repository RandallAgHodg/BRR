using BRR.Application.Core.Extensions;
using FluentValidation;

namespace BRR.Application.Houses.Commands.ApproveHouseProposal;

public sealed class ApproveHouseProposalCommandValidator : AbstractValidator<ApproveHouseProposalCommand>
{
    public ApproveHouseProposalCommandValidator()
    {
        RuleFor(x => x.clientId)
            .IsRequired("id_cliente");

        RuleFor(x => x.houseId)
            .IsRequired("id_casa");
    }
}
