using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Comments.Domain.Entities;
[Table(nameof(CommentLocalization), Schema = nameof(SchemaConsts.Localization))]
public class CommentLocalization : BaseLocalization
{
    public string Text { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public Guid CommentId { get; set; }
    public Comment Comment { get; set; }
}
