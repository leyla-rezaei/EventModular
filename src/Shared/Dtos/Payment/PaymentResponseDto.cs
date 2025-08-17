using EventModular.Shared.Enums.Payment;

namespace EventModular.Shared.Dtos.Payment;
public class PaymentResponseDto 
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid PaymentGatewayId { get; set; }
    public Guid InvoiceId { get; set; }
    public decimal Amount { get; set; }
    public string CurrencyCode { get; set; }
    public PaymentStatus Status { get; set; }
    public DateTime PaymentDate { get; set; }
}
