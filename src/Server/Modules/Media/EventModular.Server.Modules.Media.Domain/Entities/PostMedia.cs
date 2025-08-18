using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Media;

namespace EventModular.Server.Modules.Media.Domain.Entities;

[Table(nameof(PostMedia), Schema = nameof(SchemaConsts.Media))]
public class PostMedia : MediaFile
{
    public PostMedia()
    {
        MediaContentType = MediaContentType.Post;
    }
    public Guid PostId { get; set; }
    public bool IsIndex { get; set; }

    public ICollection<PostMediaLocalization> Localizations { get; set; } = new List<PostMediaLocalization>(); 
}
