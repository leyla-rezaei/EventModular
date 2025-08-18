using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Live.Domain.Entities;
[Table(nameof(LiveQuestionLocalization), Schema = SchemaConsts.Localization)]
public class LiveQuestionLocalization : BaseLocalization
{
    public Guid LiveQuestionId { get; set; }
    public string Question { get; set; } = string.Empty;
    public string? Answer { get; set; }

}
