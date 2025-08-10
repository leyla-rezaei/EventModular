using EventModular.Shared.Constants;

namespace EventModular.Shared.Base.Entities;

[Table(nameof(Language), Schema = nameof(SchemaConsts.Base))]
public class Language : BaseEntity
{
    public string Country { get; set; }
    public string Name { get; set; }
    public string Key { get; set; }
    public string LanguageNameWithItsCharacter { get; set; }

    #region Navigation properties
    #endregion
}
