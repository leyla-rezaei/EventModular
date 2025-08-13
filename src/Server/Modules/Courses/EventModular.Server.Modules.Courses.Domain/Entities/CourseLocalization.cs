using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Courses.Domain.Entities;
[Table(nameof(CourseLocalization), Schema = SchemaConsts.Localization)]
public class CourseLocalization : BaseLocalization
{
    public Guid CourseId { get; set; }
    public Course Course { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
