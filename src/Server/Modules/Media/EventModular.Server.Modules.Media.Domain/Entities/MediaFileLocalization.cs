using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Media.Domain.Entities;
[Table(nameof(MediaFileLocalization), Schema = nameof(SchemaConsts.Localization))]
public class MediaFileLocalization : BaseLocalization
{
    public Guid MediaFileId { get; set; }
    public MediaFile MediaFile { get; set; }

    public string DisplayName { get; set; } = string.Empty;   
    public string? Description { get; set; }  
}
