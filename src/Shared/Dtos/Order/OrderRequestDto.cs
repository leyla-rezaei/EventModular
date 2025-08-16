using EventModular.Shared.Enums.Order;

namespace EventModular.Shared.Dtos.Order;
public class OrderRequestDto
{
    public Guid BuyerUserId { get; set; }
    public string CurrencyCode { get; set; }
    public Guid? RelatedEntityId { get; set; }
    public string? RelatedEntityType { get; set; }
    public OrderSource Source { get; set; }
    public decimal Subtotal { get; set; }
    public decimal DiscountTotal { get; set; }
    public decimal TaxTotal { get; set; }
    public decimal GrandTotal { get; set; }
    public OrderStatus Status { get; set; }
    public List<OrderItemRequestDto> Items { get; set; }
    public List<OrderLocalizationDto>? Localizations { get; set; }

}


public class OrderLocalizationDto
{
    public string Key { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
}
