using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Courses.Domain.Entities;

[Table(nameof(CourseCategory), Schema = nameof(SchemaConsts.Course))]
public class CourseCategory : BaseEntity
{
    public Guid CourseId { get; set; }
    public Guid CategoryId { get; set; }
}
