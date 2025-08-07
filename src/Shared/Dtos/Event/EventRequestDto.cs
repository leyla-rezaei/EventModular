namespace EventModular.Shared.Dtos.Event;
public class EventRequestDto
{
    public bool IsOnline { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Guid OrganizerId { get; set; }
    public string Location { get; set; } = string.Empty;
    public string DefaultLanguage { get; set; } = string.Empty;
    public string DefaultCurrency { get; set; } = string.Empty;
    public List<EventLocalizationDto>? Localizations { get; set; }
}
public class EventLocalizationDto
{
    public string Key { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
