using EventModular.Shared.Enums.Order;

namespace EventModular.Shared.Dtos.Order;
public class OrderItemResponseDto
{
    public Guid Id { get; set; }
    public decimal LineTotal { get; set; }
    public Guid ProductId { get; set; }
    public string SnapshotTitle { get; set; } = string.Empty;
    public string? SnapshotDescription { get; set; }
    public decimal UnitPriceSnapshot { get; set; }
    public string CurrencyCode { get; set; }
    public int Quantity { get; set; }
    public Guid OrderId { get; set; }
    public ProductKind ProductKind { get; set; }
    public decimal UnitPrice { get; set; }
    public string? SnapshotJson { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; }
}




