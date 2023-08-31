using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BRR.Infrastructure.Authentication.Options;

public sealed class JWTOptionsSetup : IConfigureOptions<JWTOptions>
{
    private const string ConfigurationSectionName = "JWTOptions";
    private readonly IConfiguration _configuration;

    public JWTOptionsSetup(IConfiguration configuration) =>
        _configuration = configuration;
    

    public void Configure(JWTOptions options) =>
        _configuration.GetSection(ConfigurationSectionName).Bind(options);
    
}
