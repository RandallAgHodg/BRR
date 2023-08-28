using BRR.Application.Core.Errors;
using BRR.Application.Core.Extensions;
using FluentValidation;

namespace BRR.Application.Users.Queries.GetUserById;

public sealed class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator() =>
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithError(ValidationErrors.User.IdIsRequired);
  
}
