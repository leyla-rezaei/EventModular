using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Orders.Domain.Entities;
[Table(nameof(OrderItemLocalization), Schema = SchemaConsts.Localization)]
public class OrderItemLocalization : BaseLocalization
{
    public Guid OrderItemId { get; set; }
    public OrderItem OrderItem { get; set; }
    public string Title { get; set; } = string.Empty; 
    public string? Description { get; set; }
}
