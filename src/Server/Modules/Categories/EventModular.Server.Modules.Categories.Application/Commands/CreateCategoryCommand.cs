using MediatR;
using EventModular.Shared.Dtos.Category;

namespace EventModular.Server.Modules.Categories.Application.Commands;
public record CreateCategoryCommand(CategoryRequestDto dto) : IRequest<Guid>;


