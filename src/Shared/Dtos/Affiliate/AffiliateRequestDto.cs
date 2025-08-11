namespace EventModular.Shared.Dtos.Affiliate;
public class AffiliateRequestDto
{
    public Guid OrganizerId { get; set; }
    public string Code { get; set; } = string.Empty;
    public decimal CommissionRate { get; set; }
    public bool IsActive { get; set; }
    public List<AffiliateLocalizationDto>? Localizations { get; set; }
}

public class AffiliateLocalizationDto
{
    public string Key { get; set; } = string.Empty; 
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}



