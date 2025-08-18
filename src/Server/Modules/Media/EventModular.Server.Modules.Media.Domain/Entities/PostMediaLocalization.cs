using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Media.Domain.Entities;

[Table(nameof(PostMediaLocalization), Schema = nameof(SchemaConsts.Localization))]
public class PostMediaLocalization : MediaFileLocalization
{
    public string Title { get; set; } = string.Empty;
    public string Alt { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;

    public Guid PostMediaId { get; set; } 
    public PostMedia PostMedia { get; set; }
}
