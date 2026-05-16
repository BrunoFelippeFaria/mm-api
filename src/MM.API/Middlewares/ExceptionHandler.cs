using FluentValidation;
using MM.Domain.Shared.Base;
using MM.Domain.Shared.Exceptions;

namespace MM.API.Middlewares;

public class ExceptionHandler(RequestDelegate  next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }

        catch (DomainException ex)
        {
            context.Response.ContentType = "application/json";

            if (ex is NotFoundException)
                context.Response.StatusCode = StatusCodes.Status404NotFound;

            if (ex is UnauthorizedException)
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;

            await context.Response.WriteAsJsonAsync(new
            {
                code = ex.Code,
                message = ex.Message
            });
        }
        
        catch (ValidationException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            await context.Response.WriteAsJsonAsync(new
            {
                code = "validation_error",
                message = "um ou mais erros de validação.",
                errors = ex.Errors.Select(e => new {
                    field = e.PropertyName,
                    message = e.ErrorMessage
                })
            });
        }
    }
}