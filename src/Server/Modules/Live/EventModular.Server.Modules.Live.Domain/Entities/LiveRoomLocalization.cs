using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Live.Domain.Entities;
[Table(nameof(LiveRoomLocalization), Schema = SchemaConsts.Localization)]
public class LiveRoomLocalization : BaseLocalization
{
    public Guid LiveRoomId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
}
