using BRR.Application.Core.Extensions;
using FluentValidation;

namespace BRR.Application.Auth.Register;

public sealed class RegisterAgentCommandValidator : AbstractValidator<RegisterAgentCommand>
{
    public RegisterAgentCommandValidator()
    {
        RuleFor(x => x.Email)
            .IsRequired("correo");

        RuleFor(x => x.Password)
            .IsRequired("Contraseña");

        RuleFor(x => x.FirstName)
            .IsRequired("Nombre");

        RuleFor(x => x.LastName)
            .IsRequired("Apellido");

        RuleFor(x => x.ProfilePicture)
            .IsRequired("Foto de perfil");
    }
}
