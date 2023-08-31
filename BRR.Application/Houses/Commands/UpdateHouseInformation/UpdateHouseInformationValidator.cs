using BRR.Application.Core.Errors;
using BRR.Application.Core.Extensions;
using FluentValidation;

namespace BRR.Application.Houses.Commands.UpdateHouseInformation;

public sealed class UpdateHouseInformationValidator : AbstractValidator<UpdateHouseCommand>
{
    public UpdateHouseInformationValidator()
    {
        RuleFor(x => x.Id)
            .IsRequired("id_casa");

        RuleFor(x => x.title)
            .IsRequired("titulo");

        RuleFor(x => x.address)
            .IsRequired("direccion");

        RuleFor(x => x.area)
            .IsRequired("area");

        RuleFor(x => x.floors)
            .IsRequired("pisos")
            .GreaterThan(0)
            .WithError(ValidationErrors.Houses.FieldHasToBeAPositiveInteger("pisos"));

        RuleFor(x => x.bathrooms)
            .IsRequired("banios")
            .GreaterThan(0)
            .WithError(ValidationErrors.Houses.FieldHasToBeAPositiveInteger("banios"));

        RuleFor(x => x.bedrooms)
            .IsRequired("dormitorios")
            .GreaterThan(0)
            .WithError(ValidationErrors.Houses.FieldHasToBeAPositiveInteger("dormitorios"));

        RuleFor(x => x.livingrooms)
            .IsRequired("habitaciones")
            .GreaterThan(0)
            .WithError(ValidationErrors.Houses.FieldHasToBeAPositiveInteger("habitaciones"));

        RuleFor(x => x.Picture)
            .IsRequired("foto");

        RuleFor(x => x.Video)
            .IsRequired("video");

        RuleFor(x => x.discount)
            .IsRequired("descuento");

        RuleFor(x => x.price)
            .IsRequired("precio")
            .GreaterThan(0)
            .WithError(ValidationErrors.Houses.FieldHasToBeAPositiveInteger("precio"));
    }
}
