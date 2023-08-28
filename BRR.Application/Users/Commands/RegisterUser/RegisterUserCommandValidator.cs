using BRR.Application.Core.Errors;
using BRR.Application.Core.Extensions;
using FluentValidation;

namespace BRR.Application.Users.Commands.RegisterUser;

public sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithError(ValidationErrors.User.UserFieldIsRequired("Primer nombre"));

        RuleFor(x => x.SecondName)
            .NotEmpty()
            .WithError(ValidationErrors.User.UserFieldIsRequired("Segundo nombre"));

        RuleFor(x => x.LastName)
          .NotEmpty()
          .WithError(ValidationErrors.User.UserFieldIsRequired("Primer apellido"));

        RuleFor(x => x.SecondLastName)
          .NotEmpty()
          .WithError(ValidationErrors.User.UserFieldIsRequired("Segundo apellido"));

        RuleFor(x => x.Age)
            .NotEmpty()
            .WithError(ValidationErrors.User.UserFieldIsRequired("edad"))
            .GreaterThan(0)
            .WithError(ValidationErrors.User.AgeHasBePositive);

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithError(ValidationErrors.User.UserFieldIsRequired("contraseña"));

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithError(ValidationErrors.User.UserFieldIsRequired("Telefono"));

        RuleFor(x => x.Gender)
            .NotEmpty()
            .WithError(ValidationErrors.User.UserFieldIsRequired("Genero"));

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("AAAAA")
            .WithError(ValidationErrors.User.UserFieldIsRequired("correo"))
            .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
            .WithError(ValidationErrors.User.EmailInvalid);

        RuleFor(x => x.Role)
            .NotEmpty()
            .WithError(ValidationErrors.User.UserFieldIsRequired("rol"));
    }
}
