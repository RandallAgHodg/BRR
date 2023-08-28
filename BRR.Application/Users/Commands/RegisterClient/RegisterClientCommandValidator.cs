using BRR.Application.Core.Errors;
using BRR.Application.Core.Extensions;
using FluentValidation;

namespace BRR.Application.Users.Commands.AddClient;

public sealed class RegisterClientCommandValidator : AbstractValidator<RegisterClientCommand>
{
    public RegisterClientCommandValidator() =>
        RuleFor(x => x.clientId)
            .NotEmpty()
            .WithError(ValidationErrors.User.IdIsRequired);  
}
