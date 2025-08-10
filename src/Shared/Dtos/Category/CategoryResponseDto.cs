using EventModular.Shared.Enums.Category;

namespace EventModular.Shared.Dtos.Category;
public class CategoryResponseDto
{
    public Guid Id { get; set; }
    public Guid ParentCategoryId { get; set; }
    public CategoryShortDto? ParentCategory { get; set; }
    public CategoryType CategoryType { get; set; }

    public List<CategoryLocalizationDto>? Localizations { get; set; } = new();
}
