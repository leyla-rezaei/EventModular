using EventModular.Server.Modules.Categories.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Enums.Category;
using MediatR;

namespace EventModular.Server.Modules.Categories.Application.Commands;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var dto = request.dto;

        var entity = new Category
        {
            ParentCategoryId = null,
            CategoryType = (CategoryType)dto.CategoryType,
            Localizations = dto.Localizations?.Select(x => new CategoryLocalization
            {
                Key = x.Key,
                CategoryId = x.ParentCategoryId,
                Title = x.Title ?? string.Empty,
                Slug = x.Slug ?? string.Empty,
                Description = x.Description ?? string.Empty
            }).ToList() ?? new List<CategoryLocalization>()
        };

        await _context.Set<Category>().AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
