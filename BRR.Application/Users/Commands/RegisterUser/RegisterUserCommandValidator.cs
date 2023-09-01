using BRR.Application.Core.Errors;
using BRR.Application.Core.Extensions;
using FluentValidation;

namespace BRR.Application.Users.Commands.RegisterUser;

public sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .IsRequired("primer nombre");

        RuleFor(x => x.SecondName)
            .IsRequired("segundo nombre");

        RuleFor(x => x.LastName)
            .IsRequired("apellido");

        RuleFor(x => x.SecondLastName)
            .IsRequired("segundo apellido");

        RuleFor(x => x.Age)
            .IsRequired("edad")
            .GreaterThan(0)
            .WithError(ValidationErrors.User.AgeHasBePositive);

        RuleFor(x => x.Password)
            .IsRequired("contraseña");

        RuleFor(x => x.PhoneNumber)
            .IsRequired("telefono");

        RuleFor(x => x.Gender)
            .IsRequired("genero");

        RuleFor(x => x.Email)
            .IsRequired("correo")
            .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
            .WithError(ValidationErrors.User.EmailInvalid);

    }
}
