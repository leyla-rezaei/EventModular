using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Rates.Domain.Entities;
[Table(nameof(Rate), Schema = nameof(SchemaConsts.Rate))]
public class Rate : BaseEntity
{
    public uint Value { get; set; }
}
