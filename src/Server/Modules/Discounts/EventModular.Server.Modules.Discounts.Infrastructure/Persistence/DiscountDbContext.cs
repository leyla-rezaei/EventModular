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

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<IBaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreationDate = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.ModificationDate = DateTime.UtcNow;
                    break;
                case EntityState.Deleted:
                    entry.Entity.IsArchived = true;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
