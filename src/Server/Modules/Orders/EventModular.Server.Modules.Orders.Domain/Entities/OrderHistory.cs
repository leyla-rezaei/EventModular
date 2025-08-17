using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Order;

namespace EventModular.Server.Modules.Orders.Domain.Entities;
[Table(nameof(OrderHistory), Schema = SchemaConsts.Order)]
public class OrderHistory : BaseEntity
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; }

    public OrderStatus PreviousStatus { get; set; }
    public OrderStatus NewStatus { get; set; }
    public string? ChangedBy { get; set; }
    public string? Note { get; set; }
    public DateTime ChangedOn { get; set; }
}
