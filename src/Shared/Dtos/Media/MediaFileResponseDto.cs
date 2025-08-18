using EventModular.Shared.Enums.Media;

namespace EventModular.Shared.Dtos.Media;
public class MediaFileResponseDto
{
    public Guid Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
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

    public List<MediaFileLocalizationDto> Localizations { get; set; } = new();
    public List<MediaUsageRequestDto> Usages { get; set; } = new();
}

public class PostMediaResponseDto : MediaFileResponseDto
{
    public Guid PostId { get; set; }
    public bool IsIndex { get; set; }
    public new List<PostMediaLocalizationDto> Localizations { get; set; } = new();
}

public class CommentMediaResponseDto : MediaFileResponseDto
{
    public Guid? CommentId { get; set; }
}


public class EventMediaResponseDto : MediaFileResponseDto
{
    public Guid EventId { get; set; }
    public bool IsCover { get; set; }
    public new List<EventMediaLocalizationDto> Localizations { get; set; } = new();
}
