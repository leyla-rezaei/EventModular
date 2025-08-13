using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Courses.Domain.Entities;
[Table(nameof(CourseLessonLocalization), Schema = SchemaConsts.Localization)]
public class CourseLessonLocalization : BaseLocalization
{
    public Guid CourseLessonId { get; set; }
    public CourseLesson CourseLesson { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
}
