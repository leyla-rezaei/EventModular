using EventModular.Shared.Dtos.Tickets;
using FluentValidation;

namespace EventModular.Server.Modules.Tickets.Application.Validations;

public class TicketValidation : AbstractValidator<TicketRequestDto>
{
    public TicketValidation()
    {
        RuleFor(x => x.EventId).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Capacity).GreaterThan(0);
        RuleForEach(x => x.Localizations!).SetValidator(new TicketLocalizationValidation());
        RuleForEach(x => x.Prices!).SetValidator(new TicketPriceValidation());
    }
}

public class TicketLocalizationValidation : AbstractValidator<TicketLocalizationDto>
{
    public TicketLocalizationValidation()
    { 
        RuleFor(x => x.Key).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
    }
}

public class TicketPriceValidation : AbstractValidator<TicketPriceDto>
{ 
    public TicketPriceValidation()
    {
        RuleFor(x => x.CurrencyCode).NotEmpty();
        RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
    }
}
