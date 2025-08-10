using EventModular.Server.Modules.Comments.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Base.Entities;
using EventModular.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EventModular.Server.Modules.Comments.Infrastructure.Persistence;
public class CommentDbContext : ModuleDbContext 
{
    public CommentDbContext(DbContextOptions<CommentDbContext> options)
        : base(options, typeof(CommentDbContext).Assembly) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var entitiesAssembly = typeof(Comment).Assembly;

        modelBuilder.Entity<Comment>()
        .HasOne(c => c.ReplyedToComment)
            .WithMany(c => c.Replies)  
        .HasForeignKey(c => c.ReplyedToCommentId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.RegisterAllEntities<IBaseEntity>(entitiesAssembly);

    }
}
