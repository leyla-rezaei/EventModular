using EventModular.Server.Modules.Tickets.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Base.Entities;
using EventModular.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EventModular.Server.Modules.Tickets.Infrastructure.Persistence;
public class TicketDbContext : ModuleDbContext
{
    public TicketDbContext(DbContextOptions<TicketDbContext> options)
        : base(options, typeof(TicketDbContext).Assembly) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entitiesAssembly = typeof(Ticket).Assembly;

        modelBuilder.RegisterAllEntities<IBaseEntity>(entitiesAssembly);

    }
}
