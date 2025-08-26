using EventModular.Shared.Contracts;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using MediatR;

namespace EventModular.Shared.Base;
public abstract class BaseModuleInstaller<TDbContext> : IModuleInstaller
    where TDbContext : DbContext
{
    public virtual void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        var assembly = GetType().Assembly;

        // MediatR
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);
        });

        // FluentValidation
        services.AddValidatorsFromAssembly(assembly);

        // Pipeline Behavior for Validation
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}
