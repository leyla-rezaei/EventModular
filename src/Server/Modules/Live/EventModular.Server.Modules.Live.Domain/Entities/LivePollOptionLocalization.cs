using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Live.Domain.Entities;
[Table(nameof(LivePollOptionLocalization), Schema = SchemaConsts.Localization)]
public class LivePollOptionLocalization : BaseLocalization
{
    public string OptionText { get; set; } = string.Empty;
    public Guid LivePollOptionId { get; set; }

    public LivePollOption LivePollOption { get; set; }
}
