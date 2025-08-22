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
        modelBuilder.Entity<EventMediaLocalization>()
            .HasOne(eml => eml.EventMedia)
            .WithMany(em => em.Localizations)
            .HasForeignKey(eml => eml.EventMediaId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<EventMediaLocalization>()
            .HasOne<MediaFileLocalization>()
            .WithOne()
            .HasForeignKey<EventMediaLocalization>(eml => eml.Id)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<PostMediaLocalization>()
       .HasOne(pml => pml.PostMedia)
       .WithMany(pm => pm.Localizations)
       .HasForeignKey(pml => pml.PostMediaId)
       .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PostMediaLocalization>()
            .HasOne<MediaFileLocalization>()
            .WithOne()
            .HasForeignKey<PostMediaLocalization>(pml => pml.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }

}
