using BRR.Application.Abstractions.Authentication;
using BRR.Domain.Entities;
using BRR.Infrastructure.Authentication.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BRR.Infrastructure.Authentication;

public sealed class JWTProvider : IJWTProvider
{
    private readonly JWTOptions _options;

    public JWTProvider(IOptions<JWTOptions> options)
    {
        _options = options.Value;
    }
    public string Create(Account account)
    {
        var claims = new Claim[] {
            new(JwtRegisteredClaimNames.Sub, account.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, account.Email),
            new("Role", account.Role.Name)
        };

        var signinCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_options.SecretKey)),
            SecurityAlgorithms.HmacSha256);


        var token = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claims,
                null,
                DateTime.UtcNow.AddHours(1),
                signinCredentials
            );

        string tokenValue = new JwtSecurityTokenHandler()
                    .WriteToken(token);
        
        return tokenValue;
    }
}
