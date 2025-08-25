using EventModular.Server.Modules.Posts.Infrastructure.Persistence;
using EventModular.Shared.Contracts;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventModular.Server.Modules.Posts.Infrastructure;
public class PostModuleInstaller :IModuleInstaller
{ 
    public void Install(IServiceCollection services, IConfiguration configuration)
    {

        //DbContext
        services.AddDbContext<PostDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("PostDb")));

        var assembly = typeof(PostModuleInstaller).Assembly;

        //MediatR
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);
        });

        //FluentValidation
        services.AddValidatorsFromAssembly(assembly);

        //Pipeline Behavior for Validation 
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}

//Pipeline Behavior for  Validation 
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var results = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = results.SelectMany(r => r.Errors).Where(f => f != null).ToList();
            if (failures.Count != 0)
                throw new FluentValidation.ValidationException(failures);
        }

        return await next();
    }
}
