using EventModular.Shared.Enums.Payment;

namespace EventModular.Shared.Dtos.Payment;
public class PaymentRequestDto
{
    public Guid OrderId { get; set; }
    public decimal Amount { get; set; }
    public string CurrencyCode { get; set; }
    public Guid PaymentGatewayId { get; set; }
}
