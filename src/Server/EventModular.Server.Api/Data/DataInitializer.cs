namespace EventModular.Server.Api.Data;

public static class DataInitializer
{
    public static async Task ApplyAllMigrationsAsync(IServiceProvider services)
    {
        await using var scope = services.CreateAsyncScope();

        // find all registered DbContexts
        var dbContexts = scope.ServiceProvider
            .GetServices<DbContext>();

        foreach (var context in dbContexts)
        {
            await context.Database.MigrateAsync();
        }
    }
}




