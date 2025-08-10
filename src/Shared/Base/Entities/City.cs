using EventModular.Shared.Constants;

namespace EventModular.Shared.Base.Entities;

[Table(nameof(City), Schema = nameof(SchemaConsts.Base))]
public class City : BaseEntity
{
    public Guid CountryStateId { get; set; }
    public Provience CountryState { get; set; }
    public string Name { get; set; }

}
