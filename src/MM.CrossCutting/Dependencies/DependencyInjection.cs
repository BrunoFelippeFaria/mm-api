using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MM.CrossCutting.Dependencies;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}