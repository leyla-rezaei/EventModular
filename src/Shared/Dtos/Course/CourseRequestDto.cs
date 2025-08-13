using EventModular.Shared.Dtos.Course.ValueObjects;

namespace EventModular.Shared.Dtos.Course;
public class CourseRequestDto
{
    public Guid OrganizerId { get; set; }
    public decimal Price { get; set; }
    public bool IsPublished { get; set; }
    public DateTime? PublishDate { get; set; }
    public string ThumbnailUrl { get; set; } = string.Empty;

    public List<CourseLocalizationDto>? Localizations { get; set; }
    public List<CourseSectionRequestDto>? Sections { get; set; }
}
public class CourseLocalizationDto
{
    public string Key { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}


public class CourseSectionRequestDto
{
    public IndexValue Index { get; set; }

    public List<CourseSectionLocalizationDto>? Localizations { get; set; }
    public List<CourseLessonRequestDto>? Lessons { get; set; }
}
public class CourseSectionLocalizationDto
{
    public string Key { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
}


public class CourseLessonRequestDto
{
    public IndexValue Index { get; set; }
    public TimeSpan Duration { get; set; }

    public List<CourseLessonLocalizationDto>? Localizations { get; set; }
}
public class CourseLessonLocalizationDto
{
    public string Key { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
}




