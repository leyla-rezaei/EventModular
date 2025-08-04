namespace EventModular.Shared.Extensions;

public static class ConfigurationManagerExtensions
{
    public static void AddModuleConfigurations(this ConfigurationManager configuration)
    {
        var moduleSettings = Directory
            .GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Modules"), "appsettings.*.json", SearchOption.AllDirectories);

        foreach (var settingFile in moduleSettings)
        {
            configuration.AddJsonFile(settingFile, optional: true, reloadOnChange: true);
        }
    }
}
