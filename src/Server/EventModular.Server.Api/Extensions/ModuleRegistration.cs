 namespace EventModular.Server.Api.Extensions;

public static class ModuleRegistration
{
    public static void RegisterModules(this IServiceCollection services, IConfiguration configuration)
    {
        var baseConnection = configuration.GetConnectionString("DefaultConnection");

        // Register Module

        // Register controllers
        
    }
}
