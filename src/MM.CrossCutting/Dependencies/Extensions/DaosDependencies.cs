using Microsoft.Extensions.DependencyInjection;

using MM.Application.Catalog.MaterialCategories.Interfaces;
using MM.Application.Catalog.Materials.Interfaces;
using MM.Application.Sales.Customers.Interfaces;
using MM.Application.Shared.Interfaces;
using MM.Infrastructure.Persistence.Daos.Catalog;
using MM.Infrastructure.Persistence.Daos.Managment;
using MM.Infrastructure.Persistence.Daos.Sales;

namespace MM.CrossCutting.Dependencies.Extensions;

public static class DaosDependencies
{
    public static IServiceCollection AddDaos(this IServiceCollection services)
    {
        services.AddScoped<ICustomersDao, CustomersDao>();
        services.AddScoped<IUsersDao, UsersDao>();
        services.AddScoped<IMaterialsDao, MaterialsDao>();
        services.AddScoped<IMaterialCategoryDao, MaterialCategoryDao>();

        return services;
    }
}