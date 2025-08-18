using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Content;

namespace EventModular.Server.Modules.Contents.Domain.Entities;
[Table(nameof(EventContent), Schema = nameof(SchemaConsts.Content))]
public class EventContent : Content
{
    public EventContent()
    {
        ContentType = ContentType.Event;
    }

    public Guid EventId { get; set; }
}
