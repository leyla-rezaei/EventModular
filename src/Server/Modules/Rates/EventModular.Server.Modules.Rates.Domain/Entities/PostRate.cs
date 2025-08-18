using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Rates.Domain.Entities;
[Table(nameof(PostRate), Schema = nameof(SchemaConsts.Rate))]
public class PostRate : BaseEntity
{
    public Guid PostId { get; set; }

    public Guid RateId { get; set; }
    public Rate Rate { get; set; }
}
