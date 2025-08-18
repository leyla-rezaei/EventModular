using EventModular.Server.Modules.AffiliateMarketing.Infrastructure.Persistence;
using EventModular.Server.Modules.Categories.Infrastructure.Persistence;
using EventModular.Server.Modules.Comments.Infrastructure.Persistence;
using EventModular.Server.Modules.Contents.Infrastructure.Persistence;
using EventModular.Server.Modules.Courses.Infrastructure.Persistence;
using EventModular.Server.Modules.Discounts.Infrastructure.Persistence;
using EventModular.Server.Modules.Events.Infrastructure.Persistence;
using EventModular.Server.Modules.Live.Infrastructure.Persistence;
using EventModular.Server.Modules.Media.Infrastructure.Persistence;
using EventModular.Server.Modules.Notifications.Infrastructure.Persistence;
using EventModular.Server.Modules.Orders.Infrastructure.Persistence;
using EventModular.Server.Modules.Organizer.Infrastructure.Persistence;
using EventModular.Server.Modules.Payments.Infrastructure.Persistence;
using EventModular.Server.Modules.Posts.Infrastructure.Persistence;
using EventModular.Server.Modules.Rates.Infrastructure.Persistence;
using EventModular.Server.Modules.Subdomains.Infrastructure.Persistence;
using EventModular.Server.Modules.Tags.Infrastructure.Persistence;
using EventModular.Server.Modules.TeamManagement.Infrastructure.Persistence;
using EventModular.Server.Modules.Tickets.Infrastructure.Persistence;
using Twilio.TwiML.Messaging;

namespace EventModular.Server.Api.Data;

public static class DataInitializer
{
    public static async Task ApplyAllMigrationsAsync(IServiceProvider services)
    {
        await using var scope = services.CreateAsyncScope();

        var contexts = new DbContext[]
        {
            scope.ServiceProvider.GetRequiredService<AppDbContext>(),
            scope.ServiceProvider.GetRequiredService<OrganizerDbContext>(),
            scope.ServiceProvider.GetRequiredService<EventDbContext>(),
            scope.ServiceProvider.GetRequiredService<CategoryDbContext>(),
            scope.ServiceProvider.GetRequiredService<CommentDbContext>(),
            scope.ServiceProvider.GetRequiredService<SubdomainDbContext>(),
            scope.ServiceProvider.GetRequiredService<PostDbContext>(),
            scope.ServiceProvider.GetRequiredService<AffiliateDbContext>(),
            scope.ServiceProvider.GetRequiredService<DiscountDbContext>(),
            scope.ServiceProvider.GetRequiredService<CourseDbContext>(),
            scope.ServiceProvider.GetRequiredService<TeamManagementDbContext>(),
            scope.ServiceProvider.GetRequiredService<TicketDbContext>(),
            scope.ServiceProvider.GetRequiredService<NotificationDbContext>(),
            scope.ServiceProvider.GetRequiredService<OrderDbContext>(),
            scope.ServiceProvider.GetRequiredService<PaymentDbContext>(),
            scope.ServiceProvider.GetRequiredService<LiveDbContext>(),
            scope.ServiceProvider.GetRequiredService<MediaDbContext>(),
            scope.ServiceProvider.GetRequiredService<TagDbContext>(),
            scope.ServiceProvider.GetRequiredService<RateDbContext>(),
            scope.ServiceProvider.GetRequiredService<ContentDbContext>(),

        }; 

        foreach (var context in contexts)
        {
            await context.Database.MigrateAsync();
        }
    }
}



