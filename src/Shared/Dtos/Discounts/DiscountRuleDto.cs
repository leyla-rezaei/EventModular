namespace EventModular.Shared.Dtos.Discounts;
public class DiscountRuleDto
{
    public Guid Id { get; set; }
    public Guid CampaignId { get; set; }
    public string RuleType { get; set; } = string.Empty;
    public string RuleValue { get; set; } = string.Empty;
}
