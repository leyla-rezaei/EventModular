using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Media.Domain.Entities;
[Table(nameof(EventMediaLocalization), Schema = nameof(SchemaConsts.Localization))]
public class EventMediaLocalization : BaseLocalization
{
    public string Title { get; set; } = string.Empty;
    public string Alt { get; set; } = string.Empty;
    public string? Caption { get; set; }
    public string? ShortDescription { get; set; }

    public Guid EventMediaId { get; set; }
    public EventMedia EventMedia { get; set; }
}
