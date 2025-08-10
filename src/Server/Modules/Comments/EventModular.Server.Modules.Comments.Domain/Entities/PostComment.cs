using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Comments.Domain.Entities;
[Table(nameof(PostComment), Schema = SchemaConsts.Comment)]

public class PostComment : Comment
{
    public Guid PostId { get; set; }
}
