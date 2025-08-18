using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Live.Domain.Entities;

[Table(nameof(LiveChatMessageLocalization), Schema = SchemaConsts.Localization)]
public class LiveChatMessageLocalization : BaseLocalization
{
    public Guid LiveChatMessageId { get; set; }
    public string Message { get; set; } = string.Empty;
}
