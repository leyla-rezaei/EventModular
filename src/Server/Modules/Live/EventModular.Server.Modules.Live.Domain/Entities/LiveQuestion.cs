using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Live.Domain.Entities;
[Table(nameof(LiveQuestion), Schema = SchemaConsts.Live)]
public class LiveQuestion : BaseEntity
{
    public Guid LiveRoomId { get; set; }
    public Guid UserId { get; set; }
    public bool IsAnswered { get; set; }
    public DateTimeOffset AskedAt { get; set; }
    public DateTimeOffset? AnsweredAt { get; set; }
    public Guid? AnsweredById { get; set; }
}
