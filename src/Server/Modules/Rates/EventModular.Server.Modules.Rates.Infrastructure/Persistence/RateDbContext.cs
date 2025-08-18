using EventModular.Server.Modules.Rates.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Base.Entities;
using EventModular.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EventModular.Server.Modules.Rates.Infrastructure.Persistence;

public class RateDbContext : ModuleDbContext, IApplicationDbContext
{
    public RateDbContext(DbContextOptions<RateDbContext> options)
        : base(options, typeof(RateDbContext).Assembly) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entitiesAssembly = typeof(Rate).Assembly;

        modelBuilder.RegisterAllEntities<IBaseEntity>(entitiesAssembly);

    }
}
