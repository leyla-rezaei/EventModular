using EventModular.Server.Modules.Categories.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Base.Entities;
using EventModular.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EventModular.Server.Modules.Categories.Infrastructure.Persistence;

public class CategoryDbContext : ModuleDbContext, IApplicationDbContext
{
    public CategoryDbContext(DbContextOptions<CategoryDbContext> options)
        : base(options, typeof(CategoryDbContext).Assembly) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entitiesAssembly = typeof(Category).Assembly;

        modelBuilder.RegisterAllEntities<IBaseEntity>(entitiesAssembly);

    }
}


