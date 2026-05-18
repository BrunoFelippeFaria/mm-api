using Microsoft.Extensions.DependencyInjection;

using MM.Application.Auth.Interfaces;
using MM.Application.Auth.Services;
using MM.Domain.Shared.Interfaces;
using MM.Infrastructure.Security;

namespace MM.CrossCutting.Dependencies.Extensions;

public static class ServicesDependencies
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHasher, Argon2PasswordHasher>();
        services.AddScoped<ITokenGenerator, TokenGenerator>();

        return services;
    }
}