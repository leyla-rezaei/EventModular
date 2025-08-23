using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Media;

namespace EventModular.Server.Modules.Media.Domain.Entities;

[Table(nameof(MediaFile), Schema = SchemaConsts.Media)]
public abstract class MediaFile : BaseEntity
{
    public string FileName { get; set; } = string.Empty;
    public long FileSize { get; set; }
    public string UniqueUrl { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string StoragePath { get; set; } = string.Empty;   
    public string? ThumbnailPath { get; set; }
    public TimeSpan? Duration { get; set; }
    public bool IsPublic { get; set; }

    public MediaType MediaType { get; set; }                  
    public FileSizeType? FileSizeType { get; set; }         
    public MediaContentType MediaContentType { get; set; }  
 

    public ICollection<MediaFileLocalization> Localizations { get; set; } = new List<MediaFileLocalization>();
}
