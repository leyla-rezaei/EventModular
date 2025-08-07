using EventModular.Server.Modules.Organizer.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Base.Entities;
using EventModular.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EventModular.Server.Modules.Organizer.Infrastructure.Persistence;

public class OrganizerDbContext : ModuleDbContext
{
    public OrganizerDbContext(DbContextOptions<OrganizerDbContext> options)
        : base(options, typeof(OrganizerDbContext).Assembly) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entitiesAssembly = typeof(OrganizerProfile).Assembly;

        modelBuilder.RegisterAllEntities<IBaseEntity>(entitiesAssembly);

    }
}
