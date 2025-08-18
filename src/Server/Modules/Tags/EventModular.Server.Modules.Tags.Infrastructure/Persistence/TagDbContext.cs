using EventModular.Server.Modules.Tags.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Base.Entities;
using EventModular.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EventModular.Server.Modules.Tags.Infrastructure.Persistence;
public class TagDbContext : ModuleDbContext, IApplicationDbContext
{
    public TagDbContext(DbContextOptions<TagDbContext> options)
        : base(options, typeof(TagDbContext).Assembly) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entitiesAssembly = typeof(Tag).Assembly;

        modelBuilder.RegisterAllEntities<IBaseEntity>(entitiesAssembly);

    }
}
