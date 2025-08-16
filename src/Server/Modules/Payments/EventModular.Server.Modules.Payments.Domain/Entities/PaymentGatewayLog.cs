using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Payments.Domain.Entities;
[Table(nameof(PaymentGatewayLog), Schema = nameof(SchemaConsts.Payment))]
public class PaymentGatewayLog : BaseEntity
{
    public long Number { get; set; }

    public Guid? InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
    public decimal Amount { get; set; }

    public string GatewayName { get; set; }
    public string GatewayMerchantId { get; set; }
    public string TransactionToken { get; set; }

    public string RequestStatusCode { get; set; }
    public string VerifyStatusCode { get; set; }

    public DateTimeOffset PaymentRequestedOn { get; set; }
    public DateTimeOffset? BackFromGatewayOn { get; set; }
    public DateTimeOffset? VerifyRequestedOn { get; set; }
    public DateTimeOffset? VerifiedOn { get; set; }

    public bool PaymentSuccessful { get; set; }

    /// <summary>اطلاعات اختصاصی درگاه به صورت JSON</summary>
    public string ExtraDataJson { get; set; }
}
