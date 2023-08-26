using BRR.Application.Abstractions.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BRR.Infrastructure.Authentication;

public sealed class UserInformationProvider : IUserInformationProvider
{
    public UserInformationProvider(IHttpContextAccessor httpContextAccessor)
    {
        string? userIdClaim = httpContextAccessor?
            .HttpContext?
            .User?
            .Claims?
            .FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?
            .Value;

        IsAuthenticated = int.TryParse(userIdClaim, out int userId);

        UserId = userId;
    }
    public bool IsAuthenticated { get; }

    public int UserId { get; }
}
