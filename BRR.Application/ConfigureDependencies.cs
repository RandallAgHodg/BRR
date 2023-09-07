using BRR.Application.Abstractions.Behaviors;
using FluentValidation;
using Mapster;
using MapsterMapper;
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

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(GlobalExceptionHandlerBehavior<,>));
        services.AddValidatorsFromAssembly(assembly);

        return services;
    }   
}