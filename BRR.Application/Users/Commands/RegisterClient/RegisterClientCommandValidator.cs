using BRR.Application.Abstractions.Authentication;
using BRR.Application.Core.Errors;
using BRR.Application.Core.Extensions;
using BRR.Domain.Repositories;
using FluentValidation;

namespace BRR.Application.Users.Commands.AddClient;

public sealed class RegisterClientCommandValidator : AbstractValidator<RegisterClientCommand>
{
    public RegisterClientCommandValidator() =>
        RuleFor(x => x.clientId)
            .NotEmpty()
            .WithError(ValidationErrors.User.IdIsRequired);
    
}
