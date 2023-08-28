using BRR.Application.Core.Errors;
using BRR.Application.Core.Extensions;
using FluentValidation;

namespace BRR.Application.Users.Commands.LoginUser;

public abstract class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(x => x.email)
            .NotEmpty()
            .WithError(ValidationErrors.User.UserFieldIsRequired("email"))
            .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
            .WithError(ValidationErrors.User.EmailInvalid);

        RuleFor(x => x.password)
            .NotEmpty()
            .WithError(ValidationErrors.User.UserFieldIsRequired("contraseña"));
    }
}
