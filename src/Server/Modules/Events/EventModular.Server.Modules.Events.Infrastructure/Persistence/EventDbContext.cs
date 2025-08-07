using EventModular.Server.Modules.Events.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Base.Entities;
using EventModular.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EventModular.Server.Modules.Events.Infrastructure.Persistence;

public class EventDbContext : ModuleDbContext, IApplicationDbContext
{
    public EventDbContext(DbContextOptions<EventDbContext> options)
        : base(options, typeof(EventDbContext).Assembly) { }
  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entitiesAssembly = typeof(Event).Assembly;

        modelBuilder.RegisterAllEntities<IBaseEntity>(entitiesAssembly);

    }
}

