using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Discounts.Domain.Entities;
[Table(nameof(DiscountRule), Schema = SchemaConsts.Discount)]
public class DiscountRule : BaseEntity
{
    public Guid CampaignId { get; set; }
    public Campaign Campaign { get; set; }

    // Condition type (e.g. "MinimumPurchaseAmount", "CategoryOnly", "FirstTimeBuyer")
    public string RuleType { get; set; } = string.Empty;

    // The bet amount (e.g. "100" for a minimum purchase or "VIP" for a specific user group)
    public string RuleValue { get; set; } = string.Empty;
}
