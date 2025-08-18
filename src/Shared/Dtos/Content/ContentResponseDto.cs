using EventModular.Shared.Enums.Content;

namespace EventModular.Shared.Dtos.Content;
public class ContentResponseDto
{
    public Guid Id { get; set; }
    public ContentType ContentType { get; set; }
    public int Order { get; set; }
    public ContentAllowingStatus ContentAllowingStatus { get; set; }
    public List<ContentLocalizationDto>? Localizations { get; set; } = new();
}

public class PostContentResponseDto : ContentResponseDto
{
    public Guid PostId { get; set; }
    public new List<PostContentLocalizationDto>? Localizations { get; set; } = new();
}

public class CourseLessonContentResponseDto : ContentResponseDto
{
    public Guid CourseLessonId { get; set; }
}

public class EventContentResponseDto : ContentResponseDto
{
    public Guid EventId { get; set; }
}
