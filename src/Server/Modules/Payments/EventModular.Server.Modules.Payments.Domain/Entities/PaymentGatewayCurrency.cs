using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Payments.Domain.Entities;

[Table(nameof(PaymentGatewayCurrency), Schema = SchemaConsts.Payment)]
public class PaymentGatewayCurrency : BaseEntity
{
    public Guid PaymentGatewayId { get; set; }
    public string CurrencyCode { get; set; }
}

