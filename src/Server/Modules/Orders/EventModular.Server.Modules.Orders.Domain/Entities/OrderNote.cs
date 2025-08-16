using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Orders.Domain.Entities;
[Table(nameof(OrderNote), Schema = SchemaConsts.Order)]
public class OrderNote : BaseEntity
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; }

    public Guid CreatedByUserId { get; set; }
    public bool IsPrivate { get; set; } = true;

    public  ICollection<OrderNoteLocalization>? Localizations { get; set; } = new List<OrderNoteLocalization>(); 

} 
