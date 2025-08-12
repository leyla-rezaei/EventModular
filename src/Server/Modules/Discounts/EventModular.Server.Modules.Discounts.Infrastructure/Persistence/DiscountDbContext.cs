using EventModular.Server.Modules.Discounts.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Base.Entities;
using Microsoft.EntityFrameworkCore;
using EventModular.Shared.Extensions;

namespace EventModular.Server.Modules.Discounts.Infrastructure.Persistence;
public class DiscountDbContext : ModuleDbContext
{
    public DiscountDbContext(DbContextOptions<DiscountDbContext> options)
        : base(options, typeof(DiscountDbContext).Assembly) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entitiesAssembly = typeof(Campaign).Assembly;

        modelBuilder.RegisterAllEntities<IBaseEntity>(entitiesAssembly);

    }
}
