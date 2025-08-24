using EventModular.Server.Modules.Discounts.Domain.Entities;
using EventModular.Server.Modules.Discounts.Infrastructure.Persistence;
using EventModular.Shared.Base.Entities;
using EventModular.Shared.Contracts.Organizer;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventModular.Server.Modules.Discounts.InfrastrucancellationTokenure.Persistence;

public class DiscountDataInitializer
{
    public static async Task InitializeAsync(DiscountDbContext context,
        IMediator mediator, CancellationToken cancellationToken)
    {
        context.Database.Migrate();

        var languages = await SeedLanguageAsync(context, cancellationToken);

        var organizerId = await mediator.Send(new GetDefaultOrganizerQuery(), cancellationToken);

        var campaignId = await SeedCampaignAsync(context, organizerId, cancellationToken);

        var couponId = await SeedCouponAsync(context, campaignId, cancellationToken);

        await SeedDiscountRuleAsync(context, campaignId, cancellationToken);
    }

    private static async Task<List<string>> SeedLanguageAsync(DiscountDbContext context, CancellationToken cancellationToken)
    {
        var Key = await context.Set<Language>()
            .Select(x => x.Key).ToListAsync(cancellationToken);

        if (!Key.Any())
        {
            return new List<string>();
        }

        return Key;
    }

    private static async Task<Guid> SeedCampaignAsync(DiscountDbContext context, Guid organizerId, 
        CancellationToken cancellationToken)
    {
        if (await context.Set<Campaign>().AnyAsync(cancellationToken))
            return (await context.Set<Campaign>().FirstAsync(cancellationToken)).Id;

        var campaign = new Campaign
        {
            OrganizerId = organizerId,
            ValidFrom = DateTime.UtcNow,
            ValidTo = DateTime.UtcNow.AddMonths(1),
            IsActive = default,
            IsForSubdomain = default,
            Localizations = new List<CampaignLocalization>()
        };

        await context.Set<Campaign>().AddAsync(campaign, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        var languages = await SeedLanguageAsync(context, cancellationToken);
        foreach (var language in languages)
        {
            campaign.Localizations.Add(new CampaignLocalization
            {
                Key = language,
                Title = $"{language} Campaign Title",
                Description = $"{language} Campaign Description",
                CampaignId = campaign.Id
            });
        }

        await context.SaveChangesAsync(cancellationToken);
        return campaign.Id;
    }

    private static async Task<Guid> SeedCouponAsync(DiscountDbContext context,
        Guid campaignId,
        CancellationToken cancellationToken)
    {
        if (await context.Set<Coupon>().AnyAsync(cancellationToken))
            return (await context.Set<Coupon>().FirstAsync(cancellationToken)).Id;

        var coupon = new Coupon
        {
            ValidFrom = DateTimeOffset.UtcNow,
            ValidTo = DateTimeOffset.UtcNow.AddMonths(1),
            Localizations = new List<CouponLocalization>()
        };

        await context.Set<Coupon>().AddAsync(coupon, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        var languages = await SeedLanguageAsync(context,cancellationToken);
        foreach (var language in languages)
        {
            coupon.Localizations.Add(new CouponLocalization
            {
                Key = language,
                Description = $"{language} Coupon Description",
                CouponId = coupon.Id
            });
        }

        await context.SaveChangesAsync(cancellationToken);
        return coupon.Id;
    }

    private static async Task SeedDiscountRuleAsync(DiscountDbContext context,
        Guid campaignId,
        CancellationToken cancellationToken)
    {
        if (await context.Set<DiscountRule>().AnyAsync(cancellationToken))
            return;

        var rule = new DiscountRule
        {
            CampaignId = campaignId,
            RuleType = string.Empty,
            RuleValue = string.Empty
        };

        await context.Set<DiscountRule>().AddAsync(rule, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}

