namespace EventModular.Shared.Dtos.Payment;
public class InvoiceResponseDto
{
    public Guid Id { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;
    public Guid OrderId { get; set; }
    public decimal TotalAmount { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public List<PaymentGatewayLogResponseDto> GatewayLogs { get; set; } = new List<PaymentGatewayLogResponseDto>();
}

public class PaymentGatewayLogResponseDto
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public string GatewayName { get; set; } = string.Empty;
    public string GatewayMerchantId { get; set; } = string.Empty;
    public string TransactionToken { get; set; } = string.Empty;
    public string RequestStatusCode { get; set; } = string.Empty;
    public string VerifyStatusCode { get; set; } = string.Empty;
    public bool PaymentSuccessful { get; set; }
    public DateTimeOffset PaymentRequestedOn { get; set; }
    public DateTimeOffset? VerifiedOn { get; set; }
    public string ExtraDataJson { get; set; } = string.Empty;
}
