using EventModular.Shared.Constants;

namespace EventModular.Shared.Base.Entities;

[Table(nameof(Currency), Schema = nameof(SchemaConsts.Base))]
public class Currency : BaseEntity
{
    #region Navigation properties
    public ICollection<CurrencyLocalization> Localizations { get; set; }
    #endregion
}
