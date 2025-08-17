using EventModular.Shared.Dtos.Payment;
using FluentValidation;

namespace EventModular.Server.Modules.Payments.Application.Validations;
public class PaymentValidation : AbstractValidator<PaymentRequestDto>
{
    public PaymentValidation()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("order id is required.");

        RuleFor(x => x.PaymentGatewayId)
            .NotEmpty().WithMessage("payment gateway id is required.");

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("amount must be > 0.");

        RuleFor(x => x.CurrencyCode)
            .NotEmpty().WithMessage("currency code is required.");
    }
}


