using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Contents.Domain.Entities;
[Table(nameof(PostContentLocalization), Schema = nameof(SchemaConsts.Localization))]
public class PostContentLocalization : ContentLocalization
{
    public Guid ContentId { get; set; }
    public PostContent Content { get; set; }
    public string Excerpt { get; set; } = string.Empty;
}
