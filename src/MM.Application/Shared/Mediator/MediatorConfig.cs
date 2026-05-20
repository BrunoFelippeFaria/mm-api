using FluentValidation;

using Mediator;

using Microsoft.Extensions.DependencyInjection;

using MM.Application.Sales.Customers.Commands.Create;
using MM.Application.Shared.Behaviours;

namespace MM.Application.Shared.Mediator;

public static class MediatorConfig
{
    public static IServiceCollection AddAppMediator(this IServiceCollection services)
    {
        services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Scoped);

        services.AddValidatorsFromAssembly(typeof(CreateCustomerCommand).Assembly);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TranslacionalBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        return services;
    }
}