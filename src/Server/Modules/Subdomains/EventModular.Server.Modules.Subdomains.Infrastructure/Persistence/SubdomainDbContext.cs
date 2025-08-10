using EventModular.Server.Modules.Subdomains.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Base.Entities;
using Microsoft.EntityFrameworkCore;
using EventModular.Shared.Extensions;

namespace EventModular.Server.Modules.Subdomains.Infrastructure.Persistence;

public class SubdomainDbContext : ModuleDbContext
{
    public SubdomainDbContext(DbContextOptions<SubdomainDbContext> options)
        : base(options, typeof(SubdomainDbContext).Assembly) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entitiesAssembly = typeof(Subdomain).Assembly;

        modelBuilder.RegisterAllEntities<IBaseEntity>(entitiesAssembly);

    }
}
