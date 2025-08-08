using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Categories.Domain.Entities;
[Table(nameof(EventCategory), Schema = nameof(SchemaConsts.Event))]
public class EventCategory : BaseEntity
{
    public Guid EventId { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

}
