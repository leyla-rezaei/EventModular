using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Categories.Domain.Entities;
[Table(nameof(PostCategory), Schema = nameof(SchemaConsts.Post))]
public class PostCategory : BaseEntity
{
    public Guid PostId { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}
