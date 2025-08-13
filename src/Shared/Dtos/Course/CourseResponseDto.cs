using EventModular.Shared.Dtos.Course.ValueObjects;

namespace EventModular.Shared.Dtos.Course;
public class CourseResponseDto
{
    public Guid Id { get; set; }
    public Guid OrganizerId { get; set; }
    public decimal Price { get; set; }
    public bool IsPublished { get; set; }
    public DateTime? PublishDate { get; set; }
    public string ThumbnailUrl { get; set; } = string.Empty;

    public List<CourseLocalizationDto>? Localizations { get; set; }
    public List<CourseSectionResponseDto>? Sections { get; set; }  
}

public class CourseSectionResponseDto : CourseSectionRequestDto
{
    public Guid Id { get; set; }
    public IndexValue Index { get; set; }

    public List<CourseSectionLocalizationDto>? Localizations { get; set; }
    public List<CourseLessonResponseDto>? Lessons { get; set; }  
}


public class CourseLessonResponseDto : CourseLessonRequestDto
{
    public Guid Id { get; set; }
    public IndexValue Index { get; set; }
    public TimeSpan Duration { get; set; }

    public List<CourseLessonLocalizationDto>? Localizations { get; set; }

}






