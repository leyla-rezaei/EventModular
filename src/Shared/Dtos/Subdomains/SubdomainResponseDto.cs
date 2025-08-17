using EventModular.Shared.Enums.Subdomain;

namespace EventModular.Shared.Dtos.Subdomains;
public class SubdomainResponseDto
{
    public Guid Id { get; set; }
    public Guid OrganizerId { get; set; }
    public string DomainName { get; set; } = string.Empty;
    public SubdomainStatus Status { get; set; }
    public DateTime? ActivatedAt { get; set; }
    public DateTime? ExpiredAt { get; set; }
    public Guid? LastPaymentId { get; set; }

    public List<SubdomainLocalizationDto>? Localizations { get; set; } = new();
    public List<SubdomainSubscriptionHistoryDto>? SubscriptionHistories { get; set; } = new();
}


public class SubdomainSubscriptionHistoryDto
{
    public Guid PaymentId { get; set; }
    public SubscriptionDuration Duration { get; set; }
    public DateTime ActivatedAt { get; set; }
    public DateTime ExpiredAt { get; set; }
}
