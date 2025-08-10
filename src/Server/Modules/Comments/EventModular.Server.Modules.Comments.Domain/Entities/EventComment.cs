using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Comments.Domain.Entities;
[Table(nameof(EventComment), Schema = SchemaConsts.Comment)]

public class EventComment : Comment
{
    public Guid EventId { get; set; }
    public bool IsBuyer { get; set; }
}
