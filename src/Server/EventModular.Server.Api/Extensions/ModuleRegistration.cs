using EventModular.Server.Modules.AffiliateMarketing.Infrastructure.Persistence;
using EventModular.Server.Modules.Categories.Infrastructure.Persistence;
using EventModular.Server.Modules.Comments.Application.Mappers;
using EventModular.Server.Modules.Comments.Infrastructure.Persistence;
using EventModular.Server.Modules.Courses.Infrastructure.Persistence;
using EventModular.Server.Modules.Discounts.Infrastructure.Persistence;
using EventModular.Server.Modules.Events.Infrastructure.Persistence;
using EventModular.Server.Modules.Organizer.Infrastructure.Persistence;
using EventModular.Server.Modules.Posts.Infrastructure.Persistence;
using EventModular.Server.Modules.Subdomains.Infrastructure.Persistence;
using EventModular.Server.Modules.TeamManagement.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;

namespace EventModular.Server.Api.Extensions;

public static class ModuleRegistration
{
    public static void RegisterModules(this IServiceCollection services, IConfiguration configuration)
    {
        // Register Module
        var baseConnection = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<OrganizerDbContext>(options =>
        {
            var connectionString = ReplaceCatalog(baseConnection, "OrganizerDb");
            options.UseSqlServer(connectionString);
        });

        services.AddDbContext<EventDbContext>(options =>
        {
            var connectionString = ReplaceCatalog(baseConnection, "EventDb");
            options.UseSqlServer(connectionString);
        });

        services.AddDbContext<CategoryDbContext>(options =>
        {
            var connectionString = ReplaceCatalog(baseConnection, "CategoryDb");
            options.UseSqlServer(connectionString);
        });

        services.AddDbContext<CommentDbContext>(options =>
        {
            var connectionString = ReplaceCatalog(baseConnection, "CommentDb");
            options.UseSqlServer(connectionString);
        });

        services.AddDbContext<SubdomainDbContext>(options =>
        {
            var connectionString = ReplaceCatalog(baseConnection, "SubdomainDb");
            options.UseSqlServer(connectionString);
        });

        services.AddDbContext<PostDbContext>(options =>
        {
            var connectionString = ReplaceCatalog(baseConnection, "PostDb");
            options.UseSqlServer(connectionString);
        });

        services.AddDbContext<AffiliateDbContext>(options =>
        {
            var connectionString = ReplaceCatalog(baseConnection, "AffiliateDb");
            options.UseSqlServer(connectionString);
        });

        services.AddDbContext<DiscountDbContext>(options =>
        {
            var connectionString = ReplaceCatalog(baseConnection, "DiscountDb");
            options.UseSqlServer(connectionString);
        });

        services.AddDbContext<CourseDbContext>(options =>
        {
            var connectionString = ReplaceCatalog(baseConnection, "CourseDb");
            options.UseSqlServer(connectionString);
        });

        services.AddDbContext<TeamManagementDbContext>(options =>
        {
            var connectionString = ReplaceCatalog(baseConnection, "OrganizerRoleDb");
            options.UseSqlServer(connectionString);
        });

        // RegisterAutoMappers
        services.AddAutoMapper(typeof(CommentProfile).Assembly);


        // Register controllers

    }
    private static string ReplaceCatalog(string connectionString, string dbName)
    {
        var builder = new SqlConnectionStringBuilder(connectionString)
        {
            InitialCatalog = dbName
        };
        return builder.ToString();
    }
}

