using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Tags.Domain.Entities;
[Table(nameof(PostTag), Schema = nameof(SchemaConsts.Tag))]
public class PostTag : BaseEntity
{
    public Guid PostId { get; set; }

    public Guid TagId { get; set; }
    public Tag Tag { get; set; }
}
