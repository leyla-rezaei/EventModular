using EventModular.Server.Modules.Live.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Base.Entities;
using EventModular.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EventModular.Server.Modules.Live.Infrastructure.Persistence;
public class LiveDbContext : ModuleDbContext, IApplicationDbContext
{
    public LiveDbContext(DbContextOptions<LiveDbContext> options)
        : base(options, typeof(LiveDbContext).Assembly) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entitiesAssembly = typeof(LiveRoom).Assembly;

        modelBuilder.RegisterAllEntities<IBaseEntity>(entitiesAssembly);

    }
}
