using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Events.Domain.Entities;
[Table(nameof(EventLocalization), Schema = SchemaConsts.Localization)]
public class EventLocalization : BaseLocalization
{
    public Guid EventId { get; set; }
    public Event Event { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
