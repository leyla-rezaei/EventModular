using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Live.Domain.Entities;
[Table(nameof(LivePollLocalization), Schema = SchemaConsts.Localization)]
public class LivePollLocalization : BaseLocalization
{
    public Guid LivePollId { get; set; }
    public LivePoll LivePoll { get; set; }
    public string Question { get; set; } = string.Empty;
}
