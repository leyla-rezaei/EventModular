using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Live.Domain.Entities;

[Table(nameof(LiveRoom), Schema = SchemaConsts.Live)]
public class LiveRoom : BaseEntity
{
    public Guid EventId { get; set; }
    public Guid OrganizerId { get; set; }

    public Guid? ThumbnailMediaId { get; set; }
    public Guid? RecordingMediaId { get; set; }

    public DateTimeOffset ScheduledStart { get; set; }
    public DateTimeOffset? ScheduledEnd { get; set; }
    public DateTimeOffset? ActualStart { get; set; }
    public DateTimeOffset? ActualEnd { get; set; }

    public bool IsActive { get; set; }
    public bool IsRecorded { get; set; }
    public bool AllowReplay { get; set; }

    //Access settings
    public bool AllowAnonymous { get; set; }
    public bool RequireTicket { get; set; }
    public bool IsPrivate { get; set; }

    // Capacity
    public int MaxParticipants { get; set; }
    public int CurrentParticipants { get; set; }

    //Interactive features
    public bool AllowChat { get; set; }
    public bool AllowQnA { get; set; }
    public bool AllowPolls { get; set; }
    public bool AllowReactions { get; set; }
    public bool AllowScreenShare { get; set; }
    public bool AllowFileShare { get; set; }

    //Security
    public bool IsPasswordProtected { get; set; }
    public string? PasswordHash { get; set; }

    //Video/Audio Quality
    public string VideoQuality { get; set; } = "HD";   // 360p, 720p, 1080p
    public bool EnableAdaptiveBitrate { get; set; }
    public bool EnableRecordingCloud { get; set; }

    // Language and translation
    public string DefaultLanguage { get; set; } = "fa";
    public bool EnableSubtitles { get; set; }
    public bool EnableSimultaneousTranslation { get; set; }

    // Monitoring
    public int TotalViewCount { get; set; }
    public int PeakConcurrentUsers { get; set; }
    public TimeSpan TotalWatchTime { get; set; }

    // Room management
    public bool IsMutedAll { get; set; }
    public bool AllowRaiseHand { get; set; }
    public bool AllowModeratorKick { get; set; }
    public bool AllowModeratorMute { get; set; }

    public ICollection<LiveRoomLocalization> Localizations { get; set; } = new List<LiveRoomLocalization>();
    public ICollection<LiveChatMessage> ChatMessages { get; set; } = new List<LiveChatMessage>();
    public ICollection<LivePoll> Polls { get; set; } = new List<LivePoll>();
}
