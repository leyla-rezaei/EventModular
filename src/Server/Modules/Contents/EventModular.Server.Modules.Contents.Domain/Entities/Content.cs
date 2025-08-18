using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Content;

namespace EventModular.Server.Modules.Contents.Domain.Entities;

[Table(nameof(Content), Schema = nameof(SchemaConsts.Content))]
public abstract class Content : BaseEntity
{
    public ContentType ContentType { get; set; } 
    public int Order { get; set; }
    public ContentAllowingStatus ContentAllowingStatus { get; set; }
}
