namespace EventModular.Shared.Dtos.Payment;
public class InvoiceRequestDto
{
    public Guid OrderId { get; set; }
    public decimal TotalAmount { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;
}
