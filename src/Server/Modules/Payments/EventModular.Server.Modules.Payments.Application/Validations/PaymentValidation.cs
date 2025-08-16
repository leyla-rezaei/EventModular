using EventModular.Shared.Dtos.Payment;
using FluentValidation;

namespace EventModular.Server.Modules.Payments.Application.Validations;
public class PaymentValidation : AbstractValidator<PaymentRequestDto>
{
    public PaymentValidation()
    {
        RuleFor(x => x.OrderId).NotEmpty();
        RuleFor(x => x.Amount).GreaterThan(0);
        RuleFor(x => x.CurrencyCode).Length(3).NotEmpty();
        RuleFor(x => x.PaymentGatewayId).NotEmpty();
    }
}
