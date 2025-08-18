namespace EventModular.Shared.Dtos.Payment;
public class PaymentAttemptDto
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public decimal AttemptedAmount { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime AttemptedOn { get; set; }
    public string? ProviderTrackingCode { get; set; }
}
