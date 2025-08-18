using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Live.Domain.Entities;
[Table(nameof(LiveChatMessage), Schema = SchemaConsts.Live)]
public class LiveChatMessage : BaseEntity
{
    public Guid LiveRoomId { get; set; }
    public Guid SenderId { get; set; }
    public DateTimeOffset SentAt { get; set; }
    public bool IsPinned { get; set; }
    public ICollection<LiveChatMessageLocalization> Localizations { get; set; } = new List<LiveChatMessageLocalization>();

}
