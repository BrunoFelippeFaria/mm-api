using Mediator;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MM.Application.Sales.Customers.Interfaces;
using MM.Application.Shared.Behaviours;
using MM.Application.Shared.Interfaces;
using MM.Application.Shared.Mediator;
using MM.Infrastructure.Persistence.Context;
using MM.Infrastructure.Persistence.Daos;
using MM.Infrastructure.Persistence.UnityOfWork;

namespace MM.CrossCutting.Dependencies;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Default"))
        );

        services.AddScoped<IUnityOfWork, UnityOfWork>();
        services.AddScoped<ICustomersDao, CustomersDao>();
        services.AddAppMediator();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TranslacionalBehaviour<,>));
        return services;
    }
}