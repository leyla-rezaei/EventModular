using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Courses.Domain.Entities;
[Table(nameof(CourseSectionLocalization), Schema = SchemaConsts.Localization)]
public class CourseSectionLocalization : BaseLocalization
{
    public Guid CourseSectionId { get; set; }
    public CourseSection CourseSection { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
}
