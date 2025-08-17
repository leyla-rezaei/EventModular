using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Live.Domain.Entities;
[Table(nameof(LiveReaction), Schema = SchemaConsts.Live)]
public class LiveReaction : BaseEntity
{
    public string Emoji { get; set; } = string.Empty;
    public DateTimeOffset SentAt { get; set; }

    public Guid LiveRoomId { get; set; }
    public LiveRoom LiveRoom { get; set; }
    public Guid UserId { get; set; }
   
}
