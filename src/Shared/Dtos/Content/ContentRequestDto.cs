using EventModular.Shared.Enums.Content;

namespace EventModular.Shared.Dtos.Content;
public class ContentRequestDto
{
    public ContentType ContentType { get; set; }
    public int Order { get; set; }
    public ContentAllowingStatus ContentAllowingStatus { get; set; }
    public List<ContentLocalizationDto>? Localizations { get; set; }
}

public class ContentLocalizationDto
{
    public string Key { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
}


public class PostContentRequestDto : ContentRequestDto
{
    public new List<PostContentLocalizationDto>? Localizations { get; set; }
}

public class PostContentLocalizationDto 
{
    public string? Excerpt { get; set; }
}


public class CourseLessonContentRequestDto : ContentRequestDto
{
    public Guid CourseLessonId { get; set; }
}

public class EventContentRequestDto : ContentRequestDto
{
    public Guid EventId { get; set; }
}
