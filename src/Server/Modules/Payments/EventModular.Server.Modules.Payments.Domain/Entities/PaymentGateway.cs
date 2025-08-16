using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Payment;

namespace EventModular.Server.Modules.Payments.Domain.Entities;
[Table(nameof(PaymentGateway), Schema = SchemaConsts.Payment)]
public class PaymentGateway : BaseEntity
{
    public string Name { get; set; } 
    public GatewayType Type { get; set; } 
    public string ApiKey { get; set; }
    public string ApiSecret { get; set; }
    public string EndpointUrl { get; set; }
    public bool IsActive { get; set; }
    public string? MerchantId { get; set; }

    public ICollection<PaymentGatewayLocalization> Localizations { get; set; } = new List<PaymentGatewayLocalization>();
    public ICollection<PaymentGatewayCurrency> PaymentGatewayCurrencies { get; set; } = new List<PaymentGatewayCurrency>();
} 
