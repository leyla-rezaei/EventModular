using EventModular.Shared.Dtos.Discounts;
using FluentValidation;

namespace EventModular.Server.Modules.Discounts.Application.Validations;
public class CouponValidation : AbstractValidator<CouponRequestDto>
{
    public CouponValidation()
    {
        RuleFor(x => x.Code).NotEmpty();
        RuleFor(x => x.DiscountValue).GreaterThan(0);
        RuleFor(x => x.ValidFrom).LessThan(x => x.ValidTo);
        RuleForEach(x => x.Localizations!).SetValidator(new CouponLocalizationValidation());
    }
}

public class CouponLocalizationValidation : AbstractValidator<CouponLocalizationDto>
{
    public CouponLocalizationValidation() 
    {
        RuleFor(x => x.Key).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}
