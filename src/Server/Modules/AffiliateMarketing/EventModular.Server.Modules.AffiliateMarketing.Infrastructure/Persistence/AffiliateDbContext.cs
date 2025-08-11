using EventModular.Server.Modules.AffiliateMarketing.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Base.Entities;
using EventModular.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EventModular.Server.Modules.AffiliateMarketing.Infrastructure.Persistence;
public class AffiliateDbContext : ModuleDbContext
{ 
    public AffiliateDbContext(DbContextOptions<AffiliateDbContext> options)
        : base(options, typeof(AffiliateDbContext).Assembly) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entitiesAssembly = typeof(Affiliate).Assembly;

        modelBuilder.RegisterAllEntities<IBaseEntity>(entitiesAssembly);

    }
}
