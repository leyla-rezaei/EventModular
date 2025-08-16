using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Order;

namespace EventModular.Server.Modules.Orders.Domain.Entities;

[Table(nameof(Order), Schema = SchemaConsts.Order)]
public class Order : BaseEntity
{
    public Guid BuyerUserId { get; set; }
    public string CurrencyCode { get; set; } 
    public decimal Subtotal { get; set; }
    public decimal DiscountTotal { get; set; }
    public decimal TaxTotal { get; set; }
    public decimal GrandTotal { get; set; }
    public OrderStatus Status { get; set; }

    // مرجع بیرونی (اختیاری): Event یا Course
    public Guid? RelatedEntityId { get; set; }
    public string? RelatedEntityType { get; set; } // "Event" | "Course" | ...
    public OrderSource Source { get; set; } 

    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    public ICollection<OrderNote> Notes { get; set; } = new List<OrderNote>();
    public ICollection<OrderTracking> Trackings { get; set; } = new List<OrderTracking>();
    public ICollection<OrderLocalization> Localizations { get; set; } = new List<OrderLocalization>();

}
