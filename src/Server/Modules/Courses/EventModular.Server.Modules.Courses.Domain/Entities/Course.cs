using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Courses.Domain.Entities;
[Table(nameof(Course), Schema = SchemaConsts.Course)]
public class Course : BaseEntity
{
    public Guid OrganizerId { get; set; }
    public Guid SubdomainId { get; set; }

    public bool IsPublished { get; set; }
    public DateTime? PublishDate { get; set; }
    public string ThumbnailUrl { get; set; } = string.Empty;

    public ICollection<CourseLocalization> Localizations { get; set; } = new List<CourseLocalization>();
    public ICollection<CourseSection> Sections { get; set; } = new List<CourseSection>();
    public ICollection<CoursePrice> Prices { get; set; } = new List<CoursePrice>();
}

