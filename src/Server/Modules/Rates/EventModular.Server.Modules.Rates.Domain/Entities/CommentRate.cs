using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Rates.Domain.Entities;
[Table(nameof(CommentRate), Schema = nameof(SchemaConsts.Rate))]
public class CommentRate : BaseEntity
{
    public Guid CommentId { get; set; }

    public Guid RateId { get; set; }
    public Rate Rate { get; set; }
}
