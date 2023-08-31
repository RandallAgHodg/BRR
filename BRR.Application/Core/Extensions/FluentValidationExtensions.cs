using BRR.Application.Core.Errors;
using BRR.Domain.Primitives;
using FluentValidation;
using FluentValidation.Validators;

namespace BRR.Application.Core.Extensions;

public static class FluentValidationExtensions
{
    public static IRuleBuilderOptions<T, TProperty> WithError<T, TProperty>(
            this IRuleBuilderOptions<T, TProperty> rule, Error error)
    {
        if (error is null)
        {
            throw new ArgumentNullException(nameof(error), "The error is required");
        }

        return rule.WithErrorCode(error.Code).WithMessage(error.Message);
    }

    public static IRuleBuilderOptions<T, TProperty> IsRequired<T, TProperty>(
            this IRuleBuilderInitial<T, TProperty> rule, string field)
    {
        if (string.IsNullOrWhiteSpace(field))
            throw new ArgumentNullException(nameof(field), "The field name is required");


        return rule
            .NotEmpty()
            .WithError(ValidationErrors.Houses.HouseFieldIsRequired(field));
    }
}
