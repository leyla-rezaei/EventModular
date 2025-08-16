using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Courses.Domain.Entities;
[Table(nameof(CoursePrice), Schema = SchemaConsts.Course)]
public class CoursePrice : BaseEntity
{
    public Guid CourseId { get; set; }
    public Course Course { get; set; }

    public string CurrencyCode { get; set; } = string.Empty; 
    public decimal Price { get; set; }
}
