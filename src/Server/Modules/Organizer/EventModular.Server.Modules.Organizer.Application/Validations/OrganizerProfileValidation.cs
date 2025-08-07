using FluentValidation;
using EventModular.Shared.Dtos.Organizer;

namespace EventModular.Server.Modules.Organizer.Application.Validations; 
public class OrganizerProfileValidation : AbstractValidator<OrganizerProfileRequestDto>
{
    public OrganizerProfileValidation()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleForEach(x => x.SupportedCurrencies)
            .SetValidator(new OrganizerSupportedCurrencyValidation());
        RuleForEach(x => x.Localizations)
             .SetValidator(new OrganizerProfileLocalizationValidation());
    }

    public class OrganizerProfileLocalizationValidation : AbstractValidator<OrganizerProfileLocalizationDto>
    { 
        public OrganizerProfileLocalizationValidation()
        {
            RuleFor(x => x.Key)
                .NotEmpty();

            RuleFor(x => x.Bio)
                .NotEmpty();

            RuleFor(x => x.ProfileName)
                 .MaximumLength(100).WithMessage("profile names cannot be longer than 100 characters.")
                .Matches(@"^[\u0600-\u06FFa-zA-Z0-9\s\-]*$")
                .WithMessage("the profile name can only contain persian and English letters, numbers, and spaces.")
                .When(x => !string.IsNullOrEmpty(x.ProfileName));
        }
    }
}
