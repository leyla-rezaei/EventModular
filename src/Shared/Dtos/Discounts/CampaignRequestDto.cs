namespace EventModular.Shared.Dtos.Discounts;

public class CampaignRequestDto
{
    public string Name { get; set; } = string.Empty;
    public DateTimeOffset ValidFrom { get; set; }
    public DateTimeOffset ValidTo { get; set; }
    public bool IsActive { get; set; }
    public List<CampaignLocalizationDto>? Localizations { get; set; }
    public List<DiscountRuleDto>? Rules { get; set; }
}

public class CampaignLocalizationDto
{
    public string Key { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
