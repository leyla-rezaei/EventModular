using EventModular.Shared.Constants;

namespace EventModular.Shared.Base.Entities;

[Table(nameof(Country), Schema = nameof(SchemaConsts.Base))]
public class Country : BaseEntity
{
    public string Name { get; set; }

    #region Navigation properties
    public ICollection<Provience> Proviences { get; set; }
 
    #endregion
}
