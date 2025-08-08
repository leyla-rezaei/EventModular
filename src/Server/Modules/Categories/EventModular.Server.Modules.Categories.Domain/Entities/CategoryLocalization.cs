using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Categories.Domain.Entities;
[Table(nameof(CategoryLocalization), Schema = nameof(SchemaConsts.Localization))]

public class CategoryLocalization : BaseLocalization
{
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
