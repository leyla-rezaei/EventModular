using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Tags.Domain.Entities;
[Table(nameof(EventTag), Schema = nameof(SchemaConsts.Tag))]
public class EventTag : BaseEntity
{
    public Guid EventId { get; set; }

    public Guid TagId { get; set; }
    public Tag Tag { get; set; }
}
