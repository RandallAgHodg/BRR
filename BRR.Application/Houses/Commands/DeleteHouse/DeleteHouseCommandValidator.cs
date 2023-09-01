using BRR.Application.Core.Extensions;
using FluentValidation;

namespace BRR.Application.Houses.Commands.DeleteHouse;

public sealed class DeleteHouseCommandValidator : AbstractValidator<DeleteHouseCommand>
{
    public DeleteHouseCommandValidator() =>
        RuleFor(x => x.houseId)
            .IsRequired("id casa");
}
