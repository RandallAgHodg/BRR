using BRR.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BRR.Infrastructure.Authentication.Validation;

public sealed class CustomUserValidator : IUserValidator<Account>{
    public Task<IdentityResult> ValidateAsync(UserManager<Account> manager, Account user)
    {
        return Task.FromResult(IdentityResult.Success);
    }
}
