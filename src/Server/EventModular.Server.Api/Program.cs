using EventModular.Shared.Extensions;

namespace EventModular.Server.Api;

public static partial class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        AppEnvironment.Set(builder.Environment.EnvironmentName);

        builder.Configuration.AddSharedConfigurations();
        builder.Configuration.AddModuleConfigurations();

        builder.WebHost.UseSentry(configureOptions: options =>
            builder.Configuration.GetRequiredSection("Logging:Sentry").Bind(options));

        builder.Services.AddSharedProjectServices(builder.Configuration);
        builder.AddServerApiProjectServices();
        builder.Services.RegisterModules(builder.Configuration);

        var app = builder.Build();
        await DataInitializer.ApplyAllMigrationsAsync(app.Services);

        app.ConfigureMiddlewares();

        await app.RunAsync();
    }
}
