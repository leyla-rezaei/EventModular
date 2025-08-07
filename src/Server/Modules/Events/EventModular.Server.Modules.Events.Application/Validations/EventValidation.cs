using EventModular.Shared.Dtos.Event;
using FluentValidation;

namespace EventModular.Server.Modules.Events.Application.Validations;
public class EventValidation : AbstractValidator<EventRequestDto>
{
    public EventValidation()
    {
        RuleFor(x => x.StartTime)
            .GreaterThan(DateTime.UtcNow)
            .WithMessage("Start time must be in the future.");

        RuleFor(x => x.EndTime)
            .GreaterThan(x => x.StartTime)
            .WithMessage("End time must be after start time.");

        RuleFor(x => x.OrganizerId)
            .NotEmpty()
            .WithMessage("Organizer ID is required.");

        RuleFor(x => x.DefaultLanguage)
            .NotEmpty()
            .WithMessage("Default language is required.");

        RuleFor(x => x.DefaultCurrency)
            .NotEmpty()
            .WithMessage("Default currency is required.");

        RuleFor(x => x.Location)
            .NotEmpty()
            .When(x => !x.IsOnline)
            .WithMessage("Location is required for physical events.");

        RuleFor(x => x.Location)
            .Empty()
            .When(x => x.IsOnline)
            .WithMessage("Location must be empty for online events.");

        RuleForEach(x => x.Localizations!)
            .SetValidator(new EventLocalizationValidation());
    }
}



public class EventLocalizationValidation : AbstractValidator<EventLocalizationDto>
{
    public EventLocalizationValidation()
    {
        RuleFor(x => x.Key)
            .NotEmpty()
            .WithMessage("Localization key is required.");

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title is required.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required.");
    }
}
