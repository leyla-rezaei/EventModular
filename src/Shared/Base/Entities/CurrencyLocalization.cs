
using EventModular.Shared.Constants;

namespace EventModular.Shared.Base.Entities;

    [Table(nameof(CurrencyLocalization), Schema = nameof(SchemaConsts.Localization))]
    public class CurrencyLocalization : BaseLocalization
    {
        public string Title { get; set; } = string.Empty;
        public string Symbole { get; set; } = string.Empty;
        public Guid CurrencyId { get; set; }
        public Currency Currency {  get; set; }
    }
