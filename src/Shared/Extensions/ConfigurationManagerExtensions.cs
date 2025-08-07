namespace EventModular.Shared.Extensions;

public static class ConfigurationManagerExtensions
{
    public static void AddModuleConfigurations(this ConfigurationManager configuration)
    {
        var projectRoot = Directory.GetCurrentDirectory();
        var modulesPath = Path.GetFullPath(Path.Combine(projectRoot, "..", "Modules"));

        if (!Directory.Exists(modulesPath))
            throw new DirectoryNotFoundException($"Modules folder not found at path: {modulesPath}");

        var moduleSettings = Directory.GetFiles(modulesPath, "appsettings.*.json", SearchOption.AllDirectories);

        foreach (var settingFile in moduleSettings)
        {
            configuration.AddJsonFile(settingFile, optional: true, reloadOnChange: true);
        }
    }
}
