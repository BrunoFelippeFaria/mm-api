using System.Threading.RateLimiting;

namespace MM.API.Extensions;

public static class RateLimiterExtension
{
    public static IServiceCollection AddAppRateLimiter(this IServiceCollection services)
    {
        services.AddRateLimiter(options =>
        {
            options.AddPolicy("auth", httpContext =>
                RateLimitPartition.GetFixedWindowLimiter(
                    partitionKey: httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown",
                    factory: _ => new FixedWindowRateLimiterOptions
                    {
                        Window = TimeSpan.FromMinutes(10),
                        PermitLimit = 10,
                        QueueLimit = 0,
                    }
                )
            );

            options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
        });

        return services;
    }
}