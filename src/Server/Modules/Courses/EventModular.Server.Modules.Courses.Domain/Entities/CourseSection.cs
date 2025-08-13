using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;
using EventModular.Shared.Dtos.Course.ValueObjects;

namespace EventModular.Server.Modules.Courses.Domain.Entities;
[Table(nameof(CourseSection), Schema = SchemaConsts.Course)]
public class CourseSection : BaseEntity
{
    public Guid CourseId { get; set; }
    public Course Course { get; set; }

    public IndexValue Index { get; set; }


    public ICollection<CourseSectionLocalization> Localizations { get; set; } = new List<CourseSectionLocalization>();
    public ICollection<CourseLesson> Lessons { get; set; } = new List<CourseLesson>();
}
