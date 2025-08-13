using EventModular.Server.Modules.Notifications.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Base.Entities;
using EventModular.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EventModular.Server.Modules.Notifications.Infrastructure.Persistence;

public class NotificationDbContext : ModuleDbContext, IApplicationDbContext
{
    public NotificationDbContext(DbContextOptions<NotificationDbContext> options)
        : base(options, typeof(NotificationDbContext).Assembly) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entitiesAssembly = typeof(Notification).Assembly;

        modelBuilder.RegisterAllEntities<IBaseEntity>(entitiesAssembly);

    }
}
