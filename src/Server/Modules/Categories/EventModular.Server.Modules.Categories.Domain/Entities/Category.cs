using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Category;

namespace EventModular.Server.Modules.Categories.Domain.Entities;
[Table(nameof(Category), Schema = nameof(SchemaConsts.Category))]
public class Category : BaseEntity
{
    public Guid? ParentCategoryId { get; set; }
    public Category ParentCategory { get; set; }
    public CategoryType CategoryType { get; set; }

    #region Navigation Properties 
    public ICollection<Category> Categories { get; set; }
    public ICollection<CategoryLocalization> Localizations { get; set; } = new List<CategoryLocalization>();
    #endregion
}
