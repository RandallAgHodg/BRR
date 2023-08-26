using BRR.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BRR.Infrastructure.Authentication.Validation;

public class CustomPasswordValidator : IPasswordValidator<AppUser>
{
    public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
    {
        return Task.FromResult(IdentityResult.Success);
    }
}
