using System.Reflection;
using System.Text;

using FluentValidation;

using Mediator;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using MM.Application.Sales.Customers.Commands.Create;
using MM.Application.Sales.Customers.Interfaces;
using MM.Application.Shared.Behaviours;
using MM.Application.Shared.Interfaces;
using MM.Application.Shared.Mediator;
using MM.Infrastructure.Persistence.Context;
using MM.Infrastructure.Persistence.Daos;
using MM.Infrastructure.Persistence.Repositories;
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
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        services.AddAppMediator();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TranslacionalBehaviour<,>));
        
        services.AddValidatorsFromAssembly(typeof(CreateCustomerCommand).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(
            options => options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
        });

        return services;
    }
}