using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Live.Domain.Entities;
[Table(nameof(LiveParticipant), Schema = SchemaConsts.Live)]
public class LiveParticipant : BaseEntity
{
    public Guid LiveRoomId { get; set; }
    public Guid UserId { get; set; }
    public bool IsModerator { get; set; }
    public bool IsMuted { get; set; }
    public bool IsKicked { get; set; }
    public DateTimeOffset JoinedAt { get; set; }
    public DateTimeOffset? LeftAt { get; set; }
}
