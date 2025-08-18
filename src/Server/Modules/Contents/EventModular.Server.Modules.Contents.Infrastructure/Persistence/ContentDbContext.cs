using EventModular.Server.Modules.Contents.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Base.Entities;
using EventModular.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EventModular.Server.Modules.Contents.Infrastructure.Persistence;
public class ContentDbContext : ModuleDbContext, IApplicationDbContext
{
    public ContentDbContext(DbContextOptions<ContentDbContext> options)
        : base(options, typeof(ContentDbContext).Assembly) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entitiesAssembly = typeof(Content).Assembly;

        modelBuilder.RegisterAllEntities<IBaseEntity>(entitiesAssembly);

    }
}
