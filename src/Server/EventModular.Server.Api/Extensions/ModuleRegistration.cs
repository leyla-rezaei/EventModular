using EventModular.Server.Api;
using EventModular.Shared.Contracts;

public static class ModuleRegistration
{
    public static void RegisterModules(this IServiceCollection services, IConfiguration configuration)
    {
        // find all IModuleInstaller classes in all assemblies
        var installers = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => typeof(IModuleInstaller).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<IModuleInstaller>();

        // install all modules
        foreach (var installer in installers)
        {
            installer.Install(services, configuration);
        }

        // auto mapper
        services.AddAutoMapper(typeof(Program).Assembly);

        // controllers
        services.AddControllers();
    }
}
