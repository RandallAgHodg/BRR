﻿using BRR.Application.Abstractions.Authentication;
using BRR.Application.Abstractions.FileStorer;
using BRR.Domain.Entities;
using BRR.Domain.Repositories;
using BRR.Domain.UOW;
using BRR.Infrastructure.Authentication;
using BRR.Infrastructure.Authentication.Options;
using BRR.Infrastructure.Authentication.Validation;
using BRR.Infrastructure.Database;
using BRR.Infrastructure.Database.Options;
using BRR.Infrastructure.FileStorer;
using BRR.Infrastructure.Repositories;
using BRR.Infrastructure.UOW;
using BRRR.Infrastructure.Database.Options;
using CloudinaryDotNet;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;

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

    public static IServiceCollection AddFileStorage(this IServiceCollection services)
    {
        var cloudSecret = "Qs2il-3qBf1kL-6QtGCIXAjgjew";
        var cloudApiKey = "959295161793324";
        var cloudName = "dk5pdixdn";

        services
            .AddSingleton(
            new Cloudinary(
                new CloudinaryDotNet.Account(
                    cloudName, cloudApiKey, cloudSecret)));

        services.AddSingleton<IFileStorerProvider, FileStorerProvider>();

        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .AddJWTAuthentication()
            .AddAuthorization()
            .AddFileStorage()
            .ConfigureOptions<DatabaseOptionsSetup>();

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

        services.AddScoped<IUserValidator<Domain.Entities.Account>, CustomUserValidator>();

        services.AddIdentityCore<Domain.Entities.Account>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequiredLength = 1;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
        })
            .AddRoles<Role>()
            .AddUserValidator<CustomUserValidator>()
            .AddEntityFrameworkStores<BRRDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<IHouseRepository, HouseRepository>();

        services.AddScoped<IAgentRepository, AgentRepository>();

        //services.AddScoped<IClientRepository, ClientRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IFileStorerProvider, FileStorerProvider>();

        return services;

    }
}
