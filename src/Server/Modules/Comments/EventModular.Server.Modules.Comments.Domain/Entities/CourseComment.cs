using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Comments.Domain.Entities;
[Table(nameof(CourseComment), Schema = SchemaConsts.Comment)]

public class CourseComment : Comment
{
    public Guid CourseId { get; set; }
    public bool IsBuyer { get; set; }
}
