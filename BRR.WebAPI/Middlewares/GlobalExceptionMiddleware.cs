using BRR.Contracts.Responses.Users;
using BRR.Domain.Primitives.Exceptions;
using FluentValidation;
using System;

namespace BRR.WebAPI.Middlewares;

public sealed class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _request;

    public GlobalExceptionMiddleware(RequestDelegate request) =>
        _request = request;
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _request(context);
        }
        catch (ValidationException exception)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            if(exception.Errors.Any()) {
                var messages = exception
                    .Errors
                    .Select(x => x.ErrorMessage)
                    .ToList();
                
                await context.Response.WriteAsJsonAsync(new ValidationFailureResponse(messages));
            }
            else
            {
                var messages = new[] { exception.Message };

                await context
                    .Response
                    .WriteAsJsonAsync(
                    new ValidationFailureResponse(messages.ToList()));
            }

        }
        catch (NotFoundException exception)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;

            var messages = new[] { exception.Message };

            await context
                .Response
                .WriteAsJsonAsync(
                new ValidationFailureResponse(messages.ToList()));
        }
        catch (ForbiddenException exception)
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;

            var messages = new[] { exception.Message };

            await context
                .Response
                .WriteAsJsonAsync(
                new ValidationFailureResponse(messages.ToList()));
        }
        catch (Exception exception)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var messages = new[] { exception.Message };

            await context
                .Response
                .WriteAsJsonAsync(
                new ValidationFailureResponse(messages));
        }
    }
}
