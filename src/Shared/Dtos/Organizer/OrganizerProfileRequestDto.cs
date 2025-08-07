namespace EventModular.Shared.Dtos.Organizer;
public class OrganizerProfileRequestDto
{
    public Guid UserId { get; set; }
    public string? ProfileImageUrl { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? Subdomain { get; set; }
    public List<OrganizerSupportedCurrencyDto>? SupportedCurrencies { get; set; }
    public List<OrganizerProfileLocalizationDto>? Localizations { get; set; }
}

public class OrganizerProfileLocalizationDto
{
    public string Key { get; set; }
    public string Bio { get; set; } = string.Empty;
    public string? ProfileName { get; set; }
}
