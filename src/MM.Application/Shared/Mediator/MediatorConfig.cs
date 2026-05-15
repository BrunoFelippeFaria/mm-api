using Microsoft.Extensions.DependencyInjection;

namespace MM.Application.Shared.Mediator;

public static class MediatorConfig
{
    public static IServiceCollection AddAppMediator(this IServiceCollection services)
    {
        services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Scoped);

        return services;
    }
}