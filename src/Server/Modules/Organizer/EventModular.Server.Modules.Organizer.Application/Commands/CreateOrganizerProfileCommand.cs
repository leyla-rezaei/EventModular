using EventModular.Shared.Dtos.Organizer;
using MediatR;

namespace EventModular.Server.Modules.Organizer.Application.Commands;
public record CreateOrganizerProfileCommand(OrganizerProfileRequestDto dto) : IRequest<OrganizerProfileResponseDto>;


