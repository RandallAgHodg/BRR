using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BRR.Application;

public static class ConfigureDependencies
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(configuration =>
        configuration.RegisterServicesFromAssemblies(assembly));

        services.AddValidatorsFromAssembly(assembly);

        return services;
    }   
}