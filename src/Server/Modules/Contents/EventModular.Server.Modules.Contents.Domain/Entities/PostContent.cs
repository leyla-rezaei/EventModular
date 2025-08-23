using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Content;

namespace EventModular.Server.Modules.Contents.Domain.Entities;
[Table(nameof(PostContent), Schema = nameof(SchemaConsts.Content))]
public class PostContent : Content
{
    public PostContent()
    {
        ContentType = ContentType.Post;
    }

    public Guid PostId { get; set; }

    public  ICollection<PostContentLocalization> Localizations  { get; set; } = new List<PostContentLocalization>();

}
