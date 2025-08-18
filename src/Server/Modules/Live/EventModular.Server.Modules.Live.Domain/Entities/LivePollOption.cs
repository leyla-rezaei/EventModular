using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Live.Domain.Entities;
[Table(nameof(LivePollOption), Schema = SchemaConsts.Live)]
public class LivePollOption : BaseEntity
{
    public string OptionText { get; set; } = string.Empty;
    public int VoteCount { get; set; }

    public Guid LivePollId { get; set; }
    public LivePoll LivePoll { get; set; }

    public ICollection<LivePollOptionLocalization> Localizations { get; set; } = new List<LivePollOptionLocalization>();
}
