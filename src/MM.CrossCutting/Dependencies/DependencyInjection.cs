using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MM.Application.Shared.Mediator;
using MM.CrossCutting.Dependencies.Extensions;

namespace MM.CrossCutting.Dependencies;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddData(configuration)
            .AddAuth(configuration)
            .AddDaos()
            .AddRepositories()
            .AddServices()
            .AddAppMediator();

        return services;
    }
}