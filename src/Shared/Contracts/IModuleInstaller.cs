namespace EventModular.Shared.Contracts;
public interface IModuleInstaller
{
    void Install(IServiceCollection services, IConfiguration configuration);
}
