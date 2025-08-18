using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Media;

namespace EventModular.Server.Modules.Media.Domain.Entities;

[Table(nameof(CommentMedia), Schema = nameof(SchemaConsts.Media))]
public class CommentMedia : MediaFile
{
    public CommentMedia()
    {
        MediaContentType = MediaContentType.Comment;
    }

    public Guid? CommentId { get; set; }
}
