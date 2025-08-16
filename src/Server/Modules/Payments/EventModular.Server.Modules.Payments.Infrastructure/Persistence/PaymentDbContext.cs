using EventModular.Server.Modules.Payments.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Base.Entities;
using EventModular.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EventModular.Server.Modules.Payments.Infrastructure.Persistence;

public class PaymentDbContext : ModuleDbContext
{
    public PaymentDbContext(DbContextOptions<PaymentDbContext> options)
        : base(options, typeof(PaymentDbContext).Assembly) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entitiesAssembly = typeof(Payment).Assembly;

        modelBuilder.RegisterAllEntities<IBaseEntity>(entitiesAssembly);

    }
}
