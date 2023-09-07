using BRR.Application.Core.Errors;
using BRR.Application.Core.Extensions;
using FluentValidation;

namespace BRR.Application.Auth.Login;

public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email)
            .IsRequired("correo")
            .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
            .WithError(ValidationErrors.User.EmailInvalid);
        
        RuleFor(x => x.Password)
            .IsRequired("Contrasenia");

        RuleFor(x => x.Role)
            .IsRequired("Rol");
    }
}
