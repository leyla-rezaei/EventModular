using EventModular.Server.Modules.Categories.Domain.Entities;
using EventModular.Server.Modules.Categories.Domain.Enums;
using EventModular.Shared.Abstractions.Persistence;
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
                Localizations = dto.Localizations?.Select(l => new CategoryLocalization
                {
                    Key = l.Key,  CategoryId =l.ParentCategoryId,
                    Title = l.Title ?? string.Empty,
                    Slug = l.Slug ?? string.Empty,
                    Description = l.Description ?? string.Empty
                }).ToList() ?? new List<CategoryLocalization>()
            };

            _context.Set<Category>().AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
