using System.Security.Cryptography.Pkcs;

namespace MM.API.Extensions;

public static class SwaggerExtension
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddOpenApiDocument(config =>
        {
            config.Title = "M&M API";
            config.Description = "API do sistema M&M Canecas e Mimos";
            config.Version = "v1";
        });

        return services;
    }

    public static WebApplication UseSwagger(this WebApplication app)
    {
        app.UseOpenApi();
        app.UseSwaggerUi(config =>
        {
            config.DocumentTitle = "MM API Docs";
            config.AdditionalSettings["filter"] = true;
            config.AdditionalSettings["docExpansion"] = "list";
            config.AdditionalSettings["operationsSorter"] = "alpha";
            config.AdditionalSettings["tagsSorter"] = "alpha";

        });
        return app;
    }
}