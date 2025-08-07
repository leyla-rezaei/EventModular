using EventModular.Server.Modules.Organizer.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;

namespace EventModular.Server.Api.Extensions;

public static class ModuleRegistration
{
    public static void RegisterModules(this IServiceCollection services, IConfiguration configuration)
    {
        var baseConnection = configuration.GetConnectionString("DefaultConnection");

        // Register Module
        services.AddDbContext<OrganizerDbContext>(options =>
        {
            var connectionString = ReplaceCatalog(baseConnection, "OrganizerDb");
            options.UseSqlServer(connectionString);
        });

        // Register controllers

    }
    private static string ReplaceCatalog(string connectionString, string dbName)
    {
        var builder = new SqlConnectionStringBuilder(connectionString)
        {
            InitialCatalog = dbName
        };
        return builder.ToString();
    }

}
