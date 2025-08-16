using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Payments.Domain.Entities;
[Table(nameof(PaymentGatewayLocalization), Schema = SchemaConsts.Localization)]

public class PaymentGatewayLocalization :BaseLocalization
{
    public Guid PaymentGatewayId { get; set; }
    public PaymentGateway PaymentGateway { get; set; }

    public string Name { get; set; }
    public string? Description { get; set; }

}
