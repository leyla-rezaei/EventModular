using EventModular.Server.Modules.Categories.Infrastructure.Persistence;
using EventModular.Server.Modules.Events.Infrastructure.Persistence;
using EventModular.Server.Modules.Organizer.Infrastructure.Persistence;

namespace EventModular.Server.Api.Extensions;

public static class ModuleRegistration
{
    public static void RegisterModules(this IServiceCollection services, IConfiguration configuration)
    {
        // Register Module
        services.AddDbContext<OrganizerDbContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddDbContext<EventDbContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddDbContext<CategoryDbContext>(options =>
         options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Register controllers

    }
}
