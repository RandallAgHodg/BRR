using BRR.WebAPI.Mapping;
using Mapster;
using MapsterMapper;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace BRR.WebAPI;

public static class ConfigureDependencies
{
    public static IServiceCollection AddOpenAPISupport(this IServiceCollection services)
    {
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "BRR API",
                    Version = "v1",
                    Description = ".NET API built using ddd and clean architecture",
                    Contact = new OpenApiContact
                    {
                        Email = "randallaghodg@gmail.com",
                        Name = "Randall Agustin Hodgson"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT"
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
            });
        }


        return services;
    }

    public static IServiceCollection AddPresentation(this IServiceCollection services) =>
        services.AddHttpContextAccessor().AddOpenAPISupport().AddSwaggerGen();
    
    
}