using EventModular.Server.Modules.Orders.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Base.Entities;
using EventModular.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EventModular.Server.Modules.Orders.Infrastructure.Persistence;
public class OrderDbContext : ModuleDbContext   
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options)
        : base(options, typeof(OrderDbContext).Assembly) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entitiesAssembly = typeof(Order).Assembly;

        modelBuilder.RegisterAllEntities<IBaseEntity>(entitiesAssembly);

    }
}

