using EventModular.Shared.Dtos.Organizer;
using FluentValidation;

namespace EventModular.Server.Modules.Organizer.Application.Validations;
public class OrganizerSupportedCurrencyValidation : AbstractValidator<OrganizerSupportedCurrencyDto>
{
    public OrganizerSupportedCurrencyValidation()
    {
        RuleFor(x => x.CurrencyCode).NotEmpty();
    } 
}
