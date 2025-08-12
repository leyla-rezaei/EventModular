using EventModular.Shared.Dtos.Discounts;
using FluentValidation;

namespace EventModular.Server.Modules.Discounts.Application.Validations;
public class CampaignValidation : AbstractValidator<CampaignRequestDto>
{
    public CampaignValidation()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.ValidFrom).LessThan(x => x.ValidTo);
        RuleForEach(x => x.Localizations!).SetValidator(new CampaignLocalizationValidation());
        RuleForEach(x => x.Rules!).SetValidator(new DiscountRuleValidation());
    }
}

public class CampaignLocalizationValidation : AbstractValidator<CampaignLocalizationDto>
{
    public CampaignLocalizationValidation()
    {
        RuleFor(x => x.Key).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}
