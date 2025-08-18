using EventModular.Shared.Enums.Subdomain;

namespace EventModular.Shared.Extensions;
public static class SubscriptionExtensions
{
    public static DateTime AddDuration(this DateTime date, SubscriptionDuration duration)
    {
        return duration switch
        {
            SubscriptionDuration.Monthly => date.AddMonths(1),
            SubscriptionDuration.SixMonths => date.AddMonths(6),
            SubscriptionDuration.Yearly => date.AddYears(1),
            SubscriptionDuration.FiveYears => date.AddYears(5),
            _ => date
        };
    }
}
