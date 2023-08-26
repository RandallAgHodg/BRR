using BRR.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BRR.Infrastructure.Authentication.Validation;

public sealed class CustomUserValidator : IUserValidator<AppUser>
{
    public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
    {
        return Task.FromResult(IdentityResult.Success);
    }
}
