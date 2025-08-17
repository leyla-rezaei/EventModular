namespace EventModular.Shared.Dtos.Live;
public class LiveRoomResponseDto : LiveRoomRequestDto
{
    public Guid Id { get; set; }

    public Guid EventId { get; set; }
    public Guid OrganizerId { get; set; }
    public string? ThumbnailUrl { get; set; }

    public DateTimeOffset ScheduledStart { get; set; }
    public DateTimeOffset? ScheduledEnd { get; set; }

    public bool AllowAnonymous { get; set; }
    public bool RequireTicket { get; set; }
    public bool IsPrivate { get; set; }
    public int MaxParticipants { get; set; }

    public bool AllowChat { get; set; } = true;
    public bool AllowQnA { get; set; } = true;
    public bool AllowPolls { get; set; } = true;
    public bool AllowReactions { get; set; } = true;

    public string VideoQuality { get; set; }
    public bool EnableAdaptiveBitrate { get; set; } = true;

    public string DefaultLanguage { get; set; }
    public bool EnableSubtitles { get; set; }
    public bool EnableSimultaneousTranslation { get; set; }

    public bool IsPasswordProtected { get; set; }
    public string? Password { get; set; }

    public DateTimeOffset? ActualStart { get; set; }
    public DateTimeOffset? ActualEnd { get; set; }
    public bool IsActive { get; set; }
    public bool IsRecorded { get; set; }
    public string? RecordingUrl { get; set; }
    public bool AllowReplay { get; set; }
    public int CurrentParticipants { get; set; }
    public List<LiveRoomLocalizationDto>? Localizations { get; set; }
   
}

