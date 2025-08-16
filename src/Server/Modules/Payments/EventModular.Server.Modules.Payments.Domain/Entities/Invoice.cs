using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Payment;

namespace EventModular.Server.Modules.Payments.Domain.Entities;
[Table(nameof(Invoice), Schema = nameof(SchemaConsts.Payment))]
public class Invoice : BaseEntity
{
    public string InvoiceNumber { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;

    public InvoiceStatus Status { get; set; }

    public ICollection<PaymentGatewayLog> GatewayLogs { get; set; } = new List<PaymentGatewayLog>();
}
