using EventModular.Shared.Dtos.Subdomains;
using FluentValidation;

namespace EventModular.Server.Modules.Subdomains.Application.Validations;

public class SubdomainValidation : AbstractValidator<SubdomainRequestDto>
{
    public SubdomainValidation()
    {
        RuleFor(x => x.OrganizerId).NotEmpty();
        RuleFor(x => x.DomainName)
            .NotEmpty()
            .Matches(@"^[a-zA-Z0-9\-\.]+$")
            .WithMessage("invalid domain name");

        RuleFor(x => x.SubscriptionDuration)
            .IsInEnum()
            .WithMessage("invalid subscription duration");

        RuleForEach(x => x.Localizations!).SetValidator(new SubdomainLocalizationValidation());
    }
}

public class SubdomainLocalizationValidation : AbstractValidator<SubdomainLocalizationDto>
{
    public SubdomainLocalizationValidation()
    {
        RuleFor(x => x.Key).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
    }
}
