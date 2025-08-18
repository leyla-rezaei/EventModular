using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Media;

namespace EventModular.Server.Modules.Media.Domain.Entities;

[Table(nameof(MediaFile), Schema = SchemaConsts.Media)]
public class MediaFile : BaseEntity
{
    public string FileName { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;   // image/png, video/mp4
    public long FileSize { get; set; }

    public string StoragePath { get; set; } = string.Empty;   
    public string? ThumbnailPath { get; set; }                
    public string UniqueUrl { get; set; } = string.Empty;   

    public MediaType MediaType { get; set; }                  
    public FileSizeType? FileSizeType { get; set; }         
    public MediaContentType MediaContentType { get; set; }  

    public int Width { get; set; }                    
    public int Height { get; set; }
    public TimeSpan? Duration { get; set; }
    public bool IsPublic { get; set; }

    public ICollection<MediaFileLocalization> Localizations { get; set; } = new List<MediaFileLocalization>();
    public ICollection<MediaUsage> Usages { get; set; } = new List<MediaUsage>();
}
