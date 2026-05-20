using MM.Infrastructure.Persistence.Seeds;

namespace MM.API.Extensions;

public static class SeedsExtension
{
    public static async Task ApplySeeds(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var seeds = scope.ServiceProvider.GetServices<ISeed>();

        foreach (var seed in seeds)
        {
            await seed.Seed();
        }
    }
}