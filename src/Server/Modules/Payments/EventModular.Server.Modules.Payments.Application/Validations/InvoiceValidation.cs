using EventModular.Shared.Dtos.Payment;
using FluentValidation;

namespace EventModular.Server.Modules.Payments.Application.Validations;
public class InvoiceValidation : AbstractValidator<InvoiceRequestDto>
{
    public InvoiceValidation()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("OrderId is required.");

        RuleFor(x => x.TotalAmount)
            .GreaterThan(0).WithMessage("TotalAmount must be > 0.");

        RuleFor(x => x.CurrencyCode)
            .NotEmpty().WithMessage("CurrencyCode is required.")
            .Length(3).WithMessage("CurrencyCode must be 3 characters.");
    }
}
