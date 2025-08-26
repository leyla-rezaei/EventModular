using EventModular.Shared.Constants.Response;
using EventModular.Shared.Dtos.Organizer;
using MediatR;

namespace EventModular.Server.Modules.Organizer.Application.Commands;
public record UpdateOrganizerProfileCommand(Guid Id, OrganizerProfileRequestDto dto)
    : IRequest<SingleResponse<OrganizerProfileResponseDto>>;
