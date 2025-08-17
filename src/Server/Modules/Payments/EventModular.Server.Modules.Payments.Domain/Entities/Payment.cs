using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Payment;

namespace EventModular.Server.Modules.Payments.Domain.Entities;
[Table(nameof(Payment), Schema = SchemaConsts.Payment)]
public class Payment : BaseEntity
{
    public Guid OrderId { get; set; }
    public Guid PaymentGatewayId { get; set; }
    public PaymentGateway PaymentGateway { get; set; }

    public Guid InvoiceId { get; set; }
    public Invoice Invoice { get; set; } 

    public string CurrencyCode { get; set; }
    public decimal Amount { get; set; }
    public PaymentStatus Status { get; set; }

    // خروجی‌های درگاه
    public string? ProviderIntentId { get; set; }
    public string? ProviderPaymentId { get; set; }
    public string? ProviderTrackingCode { get; set; }
    public string? RawResponseJson { get; set; }
    public ICollection<PaymentAttempt> Attempts { get; set; } = new List<PaymentAttempt>();
}
