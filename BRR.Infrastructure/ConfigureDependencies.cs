using BRR.Application.Abstractions.Authentication;
using BRR.Domain.Entities;
using BRR.Domain.Repositories;
using BRR.Infrastructure.Authentication;
using BRR.Infrastructure.Authentication.Options;
using BRR.Infrastructure.Authentication.Validation;
using BRR.Infrastructure.Database;
using BRR.Infrastructure.Database.Options;
using BRR.Infrastructure.Repositories;
using BRRR.Infrastructure.Database.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


namespace BRR.Infrastructure;

public static class ConfigureDependencies
{
    public static IServiceCollection AddJWTAuthentication(this IServiceCollection services)
    {
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        services
            .ConfigureOptions<JWTOptionsSetup>()
            .ConfigureOptions<JWTBearerOptionSetup>();


        services.AddScoped<IJWTProvider, JWTProvider>();

        services.AddScoped<IUserInformationProvider, UserInformationProvider>();

        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.ConfigureOptions<DatabaseOptionsSetup>();

        services.AddDbContext<BRRDbContext>(
            (serviceProvider, dbContextOptionsBuilder) =>
            {
                var databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;

                dbContextOptionsBuilder
                .UseSqlServer(databaseOptions.ConnectionString, databaseServerAction =>
                {
                    databaseServerAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);

                    databaseServerAction.CommandTimeout(databaseOptions.CommandTimeout);
                });

                dbContextOptionsBuilder.EnableDetailedErrors(databaseOptions.EnabledDetailedErrors);

                dbContextOptionsBuilder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
            }
        );

        services.AddScoped<IUserValidator<AppUser>, CustomUserValidator>();

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddIdentity<AppUser, AppRole>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequiredLength = 1;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
        })
            .AddEntityFrameworkStores<BRRDbContext>()
            .AddUserValidator<CustomUserValidator>()
            .AddDefaultTokenProviders();
        return services;

    }
}
