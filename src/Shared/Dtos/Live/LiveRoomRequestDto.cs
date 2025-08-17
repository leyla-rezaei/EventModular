namespace EventModular.Shared.Dtos.Live;
public class LiveRoomRequestDto
{
    public Guid EventId { get; set; }
    public Guid OrganizerId { get; set; }
    public string? ThumbnailUrl { get; set; }
    public DateTimeOffset ScheduledStart { get; set; }
    public DateTimeOffset? ScheduledEnd { get; set; }
    public bool IsActive { get; set; }
    public bool IsRecorded { get; set; }
    public string? RecordingUrl { get; set; }
    public bool AllowReplay { get; set; }
    public bool AllowAnonymous { get; set; }
    public bool RequireTicket { get; set; }
    public bool IsPrivate { get; set; }
    public int MaxParticipants { get; set; }
    public string VideoQuality { get; set; } = "HD";
    public bool EnableAdaptiveBitrate { get; set; }
    public bool EnableRecordingCloud { get; set; }
    public string DefaultLanguage { get; set; } = "fa";
    public bool EnableSubtitles { get; set; }
    public bool EnableSimultaneousTranslation { get; set; }
    public ICollection<LiveRoomLocalizationDto> Localizations { get; set; }
}


public class LiveRoomLocalizationDto
{
    public string Key { get; set; } 
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
}
