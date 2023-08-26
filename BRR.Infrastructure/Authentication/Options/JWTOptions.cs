namespace BRR.Infrastructure.Authentication.Options;

public sealed class JWTOptions
{
    public string Audience { get; init; }
    public string Issuer { get; init; }
    public string SecretKey { get; init; }
}
