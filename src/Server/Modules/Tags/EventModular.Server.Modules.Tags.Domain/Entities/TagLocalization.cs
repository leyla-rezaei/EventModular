using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Tags.Domain.Entities;
[Table(nameof(TagLocalization), Schema = nameof(SchemaConsts.Localization))]
public class TagLocalization : BaseLocalization
{
    public string TagName { get; set; } = string.Empty;

    public Guid TagId { get; set; }
    public Tag Tag { get; set; }
}
