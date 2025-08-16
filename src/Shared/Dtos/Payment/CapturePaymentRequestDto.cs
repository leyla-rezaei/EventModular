namespace EventModular.Shared.Dtos.Payment;
public class CapturePaymentRequestDto
{
    public Guid PaymentId { get; set; }
    public bool Success { get; set; }
    public string? ProviderPaymentId { get; set; }
    public string? RawResponseJson { get; set; }
}
