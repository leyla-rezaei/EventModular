using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Base.Entities;
using EventModular.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using EventModular.Server.Modules.Courses.Domain.Entities;

namespace EventModular.Server.Modules.Courses.Infrastructure.Persistence;
public class CourseDbContext : ModuleDbContext
{ 
    public CourseDbContext(DbContextOptions<CourseDbContext> options)
        : base(options, typeof(CourseDbContext).Assembly) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entitiesAssembly = typeof(Course).Assembly;

        modelBuilder.RegisterAllEntities<IBaseEntity>(entitiesAssembly);

    }
}
