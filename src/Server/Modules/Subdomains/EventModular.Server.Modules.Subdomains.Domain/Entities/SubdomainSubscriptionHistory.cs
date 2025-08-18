using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Subdomain;

namespace EventModular.Server.Modules.Subdomains.Domain.Entities;
[Table(nameof(SubdomainSubscriptionHistory), Schema = SchemaConsts.Subdomain)]
public class SubdomainSubscriptionHistory : BaseEntity
{
    public Guid SubdomainId { get; set; }
    public Guid PaymentId { get; set; }
    public SubscriptionDuration Duration { get; set; }
    public DateTime ActivatedAt { get; set; }
    public DateTime ExpiredAt { get; set; }
}

