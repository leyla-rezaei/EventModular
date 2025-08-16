using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Orders.Domain.Entities;
[Table(nameof(OrderLocalization), Schema = SchemaConsts.Localization)]
public class OrderLocalization : BaseLocalization
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    public string Title { get; set; } = string.Empty; 
    public string? Description { get; set; }
}
