using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Rates.Domain.Entities;
[Table(nameof(EventRate), Schema = nameof(SchemaConsts.Rate))]
public class EventRate : BaseEntity
{
    public Guid EventId { get; set; }

    public Guid RateId { get; set; }
    public Rate Rate { get; set; }
}
