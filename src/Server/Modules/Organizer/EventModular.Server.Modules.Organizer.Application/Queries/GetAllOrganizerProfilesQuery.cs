using EventModular.Shared.Constants.Response;
using EventModular.Shared.Dtos.Organizer;
using MediatR;

namespace EventModular.Server.Modules.Organizer.Application.Queries;
public record GetAllOrganizerProfilesQuery()
    : IRequest<ListResponse<OrganizerProfileResponseDto>>;
