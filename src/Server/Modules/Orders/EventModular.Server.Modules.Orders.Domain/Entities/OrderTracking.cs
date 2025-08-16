using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Order;

namespace EventModular.Server.Modules.Orders.Domain.Entities;
[Table(nameof(OrderTracking), Schema = SchemaConsts.Order)]
public class OrderTracking : BaseEntity
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    public OrderTrackingStatus Status { get; set; }
    public OrderTrackingType Type { get; set; }

    public ICollection<OrderTrackingLocalization> Localizations { get; set; } = new List<OrderTrackingLocalization>();  

}
