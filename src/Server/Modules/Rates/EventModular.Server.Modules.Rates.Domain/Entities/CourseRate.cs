using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Rates.Domain.Entities;
[Table(nameof(CourseRate), Schema = nameof(SchemaConsts.Rate))]
public class CourseRate : BaseEntity
{
    public Guid CourseId { get; set; }

    public Guid RateId { get; set; }
    public Rate Rate { get; set; }
} 
