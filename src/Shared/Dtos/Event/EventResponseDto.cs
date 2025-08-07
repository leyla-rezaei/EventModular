namespace EventModular.Shared.Dtos.Event;
public class EventResponseDto
{
    public Guid Id { get; set; }
    public bool IsOnline { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Guid OrganizerId { get; set; }
    public string Location { get; set; } = string.Empty;
    public string DefaultLanguage { get; set; } = string.Empty;
    public string DefaultCurrency { get; set; } = string.Empty;
    public List<EventLocalizationDto>? Localizations { get; set; } = new();

}
