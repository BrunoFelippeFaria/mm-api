using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MM.Application.Shared.Interfaces;
using MM.Infrastructure.Persistence.Context;
using MM.Infrastructure.Persistence.Seeds;
using MM.Infrastructure.Persistence.UnityOfWork;

namespace MM.CrossCutting.Dependencies.Extensions;

public static class DataDependencies
{
    public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Default"))
        );

        services.AddScoped<ISeed, AdminSeed>();
        services.AddScoped<IUnityOfWork, UnityOfWork>();

        return services;
    }
}