using Microsoft.EntityFrameworkCore;
using System.Reflection;
using EventModular.Shared.Extensions;
using EventModular.Shared.Base.Entities;

namespace EventModular.Shared.Abstractions.Persistence;
public abstract class ModuleDbContext : DbContext
{
    private readonly Assembly _entitiesAssembly;

    protected ModuleDbContext(DbContextOptions options, Assembly entitiesAssembly)
        : base(options)
    {
        _entitiesAssembly = entitiesAssembly;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.RegisterAllEntities<IBaseEntity>(_entitiesAssembly);
        base.OnModelCreating(modelBuilder);
    }

    public new virtual DbSet<TEntity> Set<TEntity>() where TEntity : class
        => base.Set<TEntity>();

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => base.SaveChangesAsync(cancellationToken);
}
