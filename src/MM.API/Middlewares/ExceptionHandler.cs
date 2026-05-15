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
            {
                context.Response.StatusCode = 404;
            }

            await context.Response.WriteAsJsonAsync(new
            {
                code = ex.Code,
                message = ex.Message 
            });
        }
    }
}