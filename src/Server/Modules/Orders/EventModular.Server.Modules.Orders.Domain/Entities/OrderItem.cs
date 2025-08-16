using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Order;

namespace EventModular.Server.Modules.Orders.Domain.Entities;
[Table(nameof(OrderItem), Schema = SchemaConsts.Order)]
public class OrderItem : BaseEntity
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; }

    // Snapshot از آیتم انتخاب‌شده
    public Guid ProductId { get; set; }                 // Id در ماژول مقصد (Ticket/Course/…)
    public ProductKind ProductKind { get; set; }        // Ticket, Course, Subscription…
    public string SnapshotTitle { get; set; } = string.Empty; // نام در زمان خرید (جای ProductName)
    public string CurrencyCode { get; set; } 
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal LineTotal { get; set; }              // UnitPrice * Quantity (بعد از تخفیف آیتمی)
    public string? SnapshotJson { get; set; }           // هر دیتای تکمیلی (اختیاری)
}
