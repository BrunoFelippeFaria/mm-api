using System.Reflection;
using System.Text;

using FluentValidation;

using Mediator;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using MM.Application.Auth.Interfaces;
using MM.Application.Auth.Services;
using MM.Application.Catalog.MaterialCategories.Interfaces;
using MM.Application.Catalog.Materials.Interfaces;
using MM.Application.Sales.Customers.Commands.Create;
using MM.Application.Sales.Customers.Interfaces;
using MM.Application.Shared.Behaviours;
using MM.Application.Shared.Interfaces;
using MM.Application.Shared.Mediator;
using MM.Domain.Shared.Interfaces;
using MM.Infrastructure.Persistence.Context;
using MM.Infrastructure.Persistence.Daos.Catalog;
using MM.Infrastructure.Persistence.Daos.Managment;
using MM.Infrastructure.Persistence.Daos.Sales;
using MM.Infrastructure.Persistence.Repositories.Catalog;
using MM.Infrastructure.Persistence.Repositories.Sales;
using MM.Infrastructure.Persistence.Seeds;
using MM.Infrastructure.Persistence.UnityOfWork;
using MM.Infrastructure.Security;

namespace MM.CrossCutting.Dependencies;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Default"))
        );

        services.AddScoped<ISeed, AdminSeed>();

        services.AddScoped<IPasswordHasher, Argon2PasswordHasher>();

        services.AddScoped<IUnityOfWork, UnityOfWork>();

        services.AddScoped<ICustomersDao, CustomersDao>();
        services.AddScoped<IUsersDao, UsersDao>();
        services.AddScoped<IMaterialsDao, MaterialsDao>();
        services.AddScoped<IMaterialCategoryDao, MaterialCategoryDao>();

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IMaterialRepository, MaterialRepository>();
        services.AddScoped<IMaterialCategoryRepository, MaterialCategoryRepository>();

        services.AddAppMediator();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TranslacionalBehaviour<,>));
        
        services.AddValidatorsFromAssembly(typeof(CreateCustomerCommand).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        services.AddScoped<ITokenGenerator, TokenGenerator>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(
        options =>
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
            };

            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    context.Token = context.Request.Cookies["access_token"];
                    return Task.CompletedTask;
                }
            };
        });

        services.AddAuthorization();

        return services;
    }
}