using EventModular.Server.Modules.TeamManagement.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Base.Entities;
using EventModular.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EventModular.Server.Modules.TeamManagement.Infrastructure.Persistence;

public class TeamManagementDbContext : ModuleDbContext
{
    public TeamManagementDbContext(DbContextOptions<TeamManagementDbContext> options)
        : base(options, typeof(TeamManagementDbContext).Assembly) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entitiesAssembly = typeof(OrganizerRole).Assembly;

        modelBuilder.RegisterAllEntities<IBaseEntity>(entitiesAssembly);

    }
}
