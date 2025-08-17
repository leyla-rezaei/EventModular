using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Subdomain;
using EventModular.Shared.Extensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EventModular.Server.Modules.Subdomains.Domain.Entities;

[Table(nameof(Subdomain), Schema = SchemaConsts.Subdomain)]
public class Subdomain : BaseEntity 

{
    public Guid OrganizerId { get; set; }
    public string DomainName { get; set; } = string.Empty;

    public SubdomainStatus Status { get; set; } = SubdomainStatus.PendingPayment;

    public DateTime? ActivatedAt { get; set; }
    public DateTime? ExpiredAt { get; set; }

    // مرجع به آخرین پرداخت موفق 
    public Guid? LastPaymentId { get; set; }

    public ICollection<SubdomainLocalization> Localizations { get; set; } = new List<SubdomainLocalization>();
    public ICollection<SubdomainSubscriptionHistory> SubscriptionHistories { get; set; } = new List<SubdomainSubscriptionHistory>();

    // فعال‌سازی اولیه
    public void Activate(Guid paymentId, SubscriptionDuration duration)
    {
        Status = SubdomainStatus.Active;
        ActivatedAt = DateTime.UtcNow;
        ExpiredAt = DateTime.UtcNow.AddDuration(duration);
        LastPaymentId = paymentId;

        SubscriptionHistories.Add(new SubdomainSubscriptionHistory
        {
            SubdomainId = Id,
            PaymentId = paymentId,
            Duration = duration,
            ActivatedAt = ActivatedAt.Value,
            ExpiredAt = ExpiredAt.Value
        });
    }

    // تمدید
    public void Renew(Guid paymentId, SubscriptionDuration duration)
    {
        if (ExpiredAt.HasValue && ExpiredAt.Value > DateTime.UtcNow)
            ExpiredAt = ExpiredAt.Value.AddDuration(duration);
        else
            ExpiredAt = DateTime.UtcNow.AddDuration(duration);

        Status = SubdomainStatus.Active;
        LastPaymentId = paymentId;

        SubscriptionHistories.Add(new SubdomainSubscriptionHistory
        {
            SubdomainId = Id,
            PaymentId = paymentId,
            Duration = duration,
            ActivatedAt = DateTime.UtcNow,
            ExpiredAt = ExpiredAt.Value
        });
    }

    public void Expire()
    {
        Status = SubdomainStatus.Expired;
    }

    public void Deactivate()
    {
        Status = SubdomainStatus.Inactive;
    }
}
