using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Posts.Domain.Entities;
[Table(nameof(PostLocalization), Schema = nameof(SchemaConsts.Localization))]
public class PostLocalization : BaseLocalization
{
    public string Slug { get; set; } = string.Empty;

    /// <summary>
    /// tags seperate by |
    /// </summary>
    public string Tags { get; set; } = string.Empty;

    public Guid PostId { get; set; }
    public Post Post { get; set; }
}
