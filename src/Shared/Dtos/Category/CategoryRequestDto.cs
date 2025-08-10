using EventModular.Shared.Enums.Category;

namespace EventModular.Shared.Dtos.Category;
public class CategoryRequestDto
{
    public CategoryType CategoryType { get; set; }

    public List<CategoryLocalizationDto>? Localizations { get; set; }
}

public class CategoryLocalizationDto
{
    public string Key { get; set; }
    public Guid ParentCategoryId { get; set; } = Guid.Empty;
    public CategoryShortDto? ParentCategory { get; set; }
    public string? Title { get; set; }
    public string? Slug { get; set; }
    public string? Description { get; set; }
}
