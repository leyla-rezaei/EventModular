using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Contents.Domain.Entities;
[Table(nameof(ContentLocalization), Schema = nameof(SchemaConsts.Localization))]
public abstract class ContentLocalization : BaseLocalization
{
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
}
