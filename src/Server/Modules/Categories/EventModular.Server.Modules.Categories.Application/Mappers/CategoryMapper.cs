using EventModular.Server.Modules.Categories.Domain.Entities;
using EventModular.Shared.Dtos.Category;
using EventModular.Shared.Enums.Category;

namespace EventModular.Server.Modules.Categories.Application.Mappers;

public static class CategoryMapper
{
    public static CategoryResponseDto ToDto(this Category category)
    {
        return new CategoryResponseDto
        {
            Id = category.Id,
            ParentCategoryId = category.Id,
            ParentCategory = category.ParentCategory == null ? null : new CategoryShortDto
            {
                Id = category.ParentCategory.Id,
                Title = category.ParentCategory.Localizations.FirstOrDefault()?.Title
            },
            CategoryType = (CategoryType)category.CategoryType,
            Localizations = category.Localizations
                .Select(x => new CategoryLocalizationDto
                {
                    Key = x.Key,
                    ParentCategoryId = x.CategoryId,
                    Title = x.Title,
                    Slug = x.Slug,
                    Description = x.Description
                }).ToList()
        };
    }
}
