using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Orders.Domain.Entities;
[Table(nameof(OrderTrackingLocalization), Schema = SchemaConsts.Localization)]

public class OrderTrackingLocalization :BaseLocalization

{
    public Guid OrderTrackingId { get; set; }
    public OrderTracking OrderTracking { get; set; }

    public string? Note { get; set; }
}
