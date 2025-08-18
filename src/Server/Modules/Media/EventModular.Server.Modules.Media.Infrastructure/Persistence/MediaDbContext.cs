using EventModular.Server.Modules.Media.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Base.Entities;
using EventModular.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EventModular.Server.Modules.Media.Infrastructure.Persistence;

public class MediaDbContext : ModuleDbContext, IApplicationDbContext
{
    public MediaDbContext(DbContextOptions<MediaDbContext> options)
        : base(options, typeof(MediaDbContext).Assembly) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entitiesAssembly = typeof(MediaFile).Assembly;

        modelBuilder.RegisterAllEntities<IBaseEntity>(entitiesAssembly);

    }
}
