namespace EventModular.Shared.Dtos.Affiliate;
public class AffiliateResponseDto
{
    public Guid Id { get; set; }
    public Guid OrganizerId { get; set; }
    public string Code { get; set; } = string.Empty;
    public decimal CommissionRate { get; set; }
    public bool IsActive { get; set; }
    public List<AffiliateLocalizationDto>? Localizations { get; set; } = new();
}
