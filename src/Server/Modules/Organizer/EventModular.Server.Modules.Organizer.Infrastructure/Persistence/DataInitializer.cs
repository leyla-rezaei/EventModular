using EventModular.Server.Modules.Organizer.Domain.Entities;
using EventModular.Shared.Base.Entities;
using EventModular.Shared.Contracts.User;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventModular.Server.Modules.Organizer.Infrastructure.Persistence;

public class OrganizerDataInitializer
{
    public static async Task InitializeAsync(OrganizerDbContext context,
        IMediator mediator, CancellationToken cancellationToken)
    {
        context.Database.Migrate();
        await SeedData(context, cancellationToken, mediator);
    }

    private static async Task SeedData(OrganizerDbContext context, CancellationToken cancellationToken, IMediator mediator)
    {
        var languages = await SeedLanguageAsync(context, cancellationToken);

        var userId = await mediator.Send(new GetDefaultUserIdQuery(), cancellationToken);

        var organizerId = await SeedOrganizerProfileAsync(context, userId, cancellationToken);

        await SeedSupportedCurrencyAsync(context, organizerId, cancellationToken);
    }

    private static async Task<List<string>> SeedLanguageAsync(OrganizerDbContext context, CancellationToken cancellationToken)
    {
        var keys = await context.Set<Language>()
            .Select(x => x.Key).ToListAsync(cancellationToken);

        if (!keys.Any())
            return new List<string>();

        return keys;
    }

    private static async Task<Guid> SeedOrganizerProfileAsync(OrganizerDbContext context, Guid userId,
         CancellationToken cancellationToken)
    {
        if (await context.Set<OrganizerProfile>().AnyAsync(cancellationToken))
            return (await context.Set<OrganizerProfile>().FirstAsync(cancellationToken)).Id;

        var profile = new OrganizerProfile
        {
            UserId = userId,
            ProfileImageUrl = null,
            WebsiteUrl = null,
            Subdomain = null,
            Localizations = new List<OrganizerProfileLocalization>()
        };

        await context.Set<OrganizerProfile>().AddAsync(profile, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        var languages = await SeedLanguageAsync(context, cancellationToken);
        foreach (var lang in languages)
        {
            profile.Localizations.Add(new OrganizerProfileLocalization
            {
                Key = lang,
                Bio = string.Empty,
                ProfileName = null, 
                OrganizerId = userId
            });
        }

        await context.SaveChangesAsync(cancellationToken);
        return profile.Id;
    }

    private static async Task SeedSupportedCurrencyAsync(OrganizerDbContext context, Guid organizerId, CancellationToken cancellationToken)
    {
        if (await context.Set<OrganizerSupportedCurrency>().AnyAsync(cancellationToken))
            return;

        var currency = new OrganizerSupportedCurrency
        {
            OrganizerId = organizerId,
            CurrencyCode = string.Empty
        };

        await context.Set<OrganizerSupportedCurrency>().AddAsync(currency, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}
