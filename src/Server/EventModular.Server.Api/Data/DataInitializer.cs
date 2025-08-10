using EventModular.Server.Modules.Categories.Infrastructure.Persistence;
using EventModular.Server.Modules.Comments.Infrastructure.Persistence;
using EventModular.Server.Modules.Events.Infrastructure.Persistence;
using EventModular.Server.Modules.Organizer.Infrastructure.Persistence;

namespace EventModular.Server.Api.Data;

public static class DataInitializer
{
    public static async Task ApplyAllMigrationsAsync(IServiceProvider services)
    {
        await using var scope = services.CreateAsyncScope();

        var contexts = new DbContext[]
        {
            scope.ServiceProvider.GetRequiredService<AppDbContext>(),
            scope.ServiceProvider.GetRequiredService<OrganizerDbContext>(), 
            scope.ServiceProvider.GetRequiredService<EventDbContext>(),
            scope.ServiceProvider.GetRequiredService<CategoryDbContext>(),
            scope.ServiceProvider.GetRequiredService<CommentDbContext>(),

        };

        foreach (var context in contexts)
        {
            await context.Database.MigrateAsync();
        }
    }
}



