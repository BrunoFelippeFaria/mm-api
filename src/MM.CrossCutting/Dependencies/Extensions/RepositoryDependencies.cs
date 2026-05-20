using Microsoft.Extensions.DependencyInjection;

using MM.Application.Catalog.MaterialCategories.Interfaces;
using MM.Application.Catalog.Materials.Interfaces;
using MM.Application.Sales.Customers.Interfaces;
using MM.Infrastructure.Persistence.Repositories.Catalog;
using MM.Infrastructure.Persistence.Repositories.Sales;

namespace MM.CrossCutting.Dependencies.Extensions;

public static class RepositoryDependencies
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IMaterialRepository, MaterialRepository>();
        services.AddScoped<IMaterialCategoryRepository, MaterialCategoryRepository>();

        return services;
    }
}