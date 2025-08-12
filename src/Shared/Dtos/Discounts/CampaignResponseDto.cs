namespace EventModular.Shared.Dtos.Discounts;
public class CampaignResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTimeOffset ValidFrom { get; set; }
    public DateTimeOffset ValidTo { get; set; }
    public bool IsActive { get; set; }
    public List<CampaignLocalizationDto>? Localizations { get; set; }
    public List<DiscountRuleDto>? Rules { get; set; }
}
