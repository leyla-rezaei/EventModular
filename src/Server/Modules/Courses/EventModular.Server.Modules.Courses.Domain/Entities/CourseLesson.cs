using EventModular.Shared.Dtos.Course.ValueObjects;
using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Courses.Domain.Entities;
[Table(nameof(CourseLesson), Schema = SchemaConsts.Course)]
public class CourseLesson : BaseEntity
{
    public Guid CourseSectionId { get; set; }
    public CourseSection CourseSection { get; set; }

    public IndexValue Index { get; set; }

    public string VideoUrl { get; set; } = string.Empty;
    public TimeSpan Duration { get; set; }

    public ICollection<CourseLessonLocalization> Localizations { get; set; } = new List<CourseLessonLocalization>();
}
