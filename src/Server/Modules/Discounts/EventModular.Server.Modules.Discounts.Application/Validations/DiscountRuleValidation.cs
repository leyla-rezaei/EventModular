using EventModular.Shared.Dtos.Discounts;
using FluentValidation;

namespace EventModular.Server.Modules.Discounts.Application.Validations;
public class DiscountRuleValidation : AbstractValidator<DiscountRuleDto>
{
    public DiscountRuleValidation()
    {
        RuleFor(x => x.CampaignId).NotNull().NotEmpty();
        RuleFor(x => x.RuleType).NotEmpty();
        RuleFor(x => x.RuleValue).NotEmpty();
    }
}
