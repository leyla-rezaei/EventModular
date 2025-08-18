using EventModular.Shared.Dtos.Tag;
using MediatR;

namespace EventModular.Server.Modules.Tags.Application.Commands;
public record CreateTagCommand(TagRequestDto dto) : IRequest<TagResponseDto>;

