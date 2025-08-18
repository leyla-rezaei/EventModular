using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Live.Domain.Entities;
[Table(nameof(LivePoll), Schema = SchemaConsts.Live)]
public class LivePoll : BaseEntity
{
    public Guid LiveRoomId { get; set; }
    public string Question { get; set; } = string.Empty;
    public bool IsAnonymous { get; set; }
    public bool IsMultipleChoice { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? ExpiresAt { get; set; }
    public bool IsClosed { get; set; }

    public ICollection<LivePollLocalization> Localizations { get; set; } = new List<LivePollLocalization>();
    public ICollection<LivePollOption> Options { get; set; } = new List<LivePollOption>();
}

