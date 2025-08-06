namespace EventModular.Shared.Dtos.Organizer;
public class OrganizerProfileResponseDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? ProfileImageUrl { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? Subdomain { get; set; }
    public List<OrganizerSupportedCurrencyDto>? SupportedCurrencies { get; set; } = new();
    public List<OrganizerProfileLocalizationDto>? Localizations { get; set; } = new();
}
