using EventModular.Shared.Enums.Media;

namespace EventModular.Shared.Dtos.Media;
public class MediaFileRequestDto
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

    public List<MediaFileLocalizationDto> Localizations { get; set; } = new();

}

public class MediaFileLocalizationDto 
{
    public string key { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string? Description { get; set; }
}

public class PostMediaRequestDto : MediaFileRequestDto
{
    public Guid PostId { get; set; }
    public bool IsIndex { get; set; }
    public new List<PostMediaLocalizationDto> Localizations { get; set; } = new();
}

public class PostMediaLocalizationDto
{
    public string Title { get; set; } = string.Empty;
    public string Alt { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
}


public class CommentMediaRequestDto : MediaFileRequestDto
{
    public Guid? CommentId { get; set; }
}

public class EventMediaRequestDto : MediaFileRequestDto
{
    public Guid EventId { get; set; }
    public bool IsCover { get; set; }
    public new List<EventMediaLocalizationDto> Localizations { get; set; } = new();
}

public class EventMediaLocalizationDto 
{
    public string Title { get; set; } = string.Empty;
    public string Alt { get; set; } = string.Empty;
    public string? Caption { get; set; }
    public string? ShortDescription { get; set; }
}
