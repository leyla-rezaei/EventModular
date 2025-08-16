using EventModular.Shared.Enums.Payment;

namespace EventModular.Shared.Dtos.Payment;
public class PaymentGatewayRequestDto
{
    public string Name { get; set; }
    public GatewayType Type { get; set; }
    public string ApiKey { get; set; }
    public string ApiSecret { get; set; }
    public string EndpointUrl { get; set; }
    public bool IsActive { get; set; }

    public List<PaymentGatewayCurrencyDto> SupportedCurrencies { get; set; } = new();
}

public class PaymentGatewayLocalizationDto
{
    public string Key { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}
