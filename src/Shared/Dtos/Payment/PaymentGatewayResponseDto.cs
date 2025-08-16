using EventModular.Shared.Enums.Payment;

namespace EventModular.Shared.Dtos.Payment;
public class PaymentGatewayResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public GatewayType Type { get; set; }
    public string ApiKey { get; set; }
    public string ApiSecret { get; set; }
    public string EndpointUrl { get; set; }
    public bool IsActive { get; set; }

    public List<PaymentGatewayLocalizationDto>? Localizations { get; set; } = new();
    public List<PaymentGatewayCurrencyDto> PaymentGatewayCurrencies { get; set; } = new();
}
