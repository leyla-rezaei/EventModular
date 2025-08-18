using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Tags.Domain.Entities;
[Table(nameof(CourseTag), Schema = nameof(SchemaConsts.Tag))]
public class CourseTag : BaseEntity
{
    public Guid CourseId { get; set; }

    public Guid TagId { get; set; }
    public Tag Tag { get; set; }
}
