using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MM.API.Extensions;

public static class HealthCheckExtension
{
    public static WebApplication AddHealthCheck(this WebApplication app)
    {

        app.MapHealthChecks("/health", new HealthCheckOptions
        {
            ResponseWriter = Write
        });

        return app;
    }

    private static async Task Write(HttpContext context, HealthReport report)
    {
        context.Response.ContentType = "application/json";

        var result = new
        {
            status = report.Status.ToString(),
            checks = report.Entries.Select(e => new
            {
                name = e.Key,
                status = e.Value.Status.ToString(),
                description = e.Value.Description
            })
        };

        await context.Response.WriteAsJsonAsync(result);
    }
}