using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Content;

namespace EventModular.Server.Modules.Contents.Domain.Entities;
[Table(nameof(CourseLessonContent), Schema = nameof(SchemaConsts.Content))]
public class CourseLessonContent : Content
{
    public CourseLessonContent()
    {
        ContentType = ContentType.CourseLesson;
    }
    public Guid CourseLessonId { get; set; }
}
