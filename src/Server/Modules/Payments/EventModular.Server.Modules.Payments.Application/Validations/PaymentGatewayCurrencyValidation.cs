using EventModular.Shared.Dtos.Payment;
using FluentValidation;

namespace EventModular.Server.Modules.Payments.Application.Validations;

public class PaymentGatewayCurrencyValidation : AbstractValidator<PaymentGatewayCurrencyDto>
{
    public PaymentGatewayCurrencyValidation()
    {
        RuleFor(x => x.CurrencyCode)
            .NotEmpty();
   
    }
}

