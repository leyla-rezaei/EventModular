using EventModular.Shared.Dtos.Affiliate;
using FluentValidation;

namespace EventModular.Server.Modules.AffiliateMarketing.Application.Validations;
public class AffiliateValidation : AbstractValidator<AffiliateRequestDto>
{
    public AffiliateValidation()
    {
        RuleFor(x => x.OrganizerId).NotEmpty();
        RuleFor(x => x.Code).NotEmpty();
        RuleFor(x => x.CommissionRate).GreaterThan(0);
        RuleForEach(x => x.Localizations!).SetValidator(new AffiliateLocalizationValidation());
    }
}
public class AffiliateLocalizationValidation : AbstractValidator<AffiliateLocalizationDto>
{
    public AffiliateLocalizationValidation()
    {
        RuleFor(x => x.Key).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}
