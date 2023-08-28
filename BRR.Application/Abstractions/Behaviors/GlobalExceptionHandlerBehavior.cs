using BRR.Application.Abstractions.Messaging;
using BRR.Domain.Primitives.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace BRR.Application.Abstractions.Behaviors;

public sealed class GlobalExceptionHandlerBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, ICommand<TResponse>
{
	private readonly IHttpContextAccessor _httpContext;

    public GlobalExceptionHandlerBehavior(IHttpContextAccessor httpContext) =>
        _httpContext = httpContext;
    

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
		try
		{
			return await next();
		}
		catch (ValidationException exception)
        {
            var context = _httpContext.HttpContext;


            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            var message = exception
                .Errors
                .Select(x => x.ErrorMessage)
                .ToList();

            var responseJSON = JsonSerializer.Serialize(message);

            await context.Response.WriteAsync(responseJSON);

            return await next();
        }
        catch (NotFoundException exception)
        {
            var context = _httpContext.HttpContext;


            context.Response.StatusCode = StatusCodes.Status404NotFound;

            var message = exception
                .Message
                .ToList();

            var responseJSON = JsonSerializer.Serialize(message);

            await context.Response.WriteAsync(responseJSON);

            return await next();
        }
    }
}
