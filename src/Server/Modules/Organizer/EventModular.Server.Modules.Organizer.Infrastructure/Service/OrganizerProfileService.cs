using EventModular.Server.Modules.Organizer.Application.Commands;
using EventModular.Server.Modules.Organizer.Application.Queries;
using EventModular.Server.Modules.Organizer.Infrastructure.Service;
using EventModular.Shared.Constants.Response;
using EventModular.Shared.Dtos.Organizer;
using MediatR;

namespace EventModular.Server.Modules.Organizer.Application.Services;

public class OrganizerProfileService : IOrganizerProfileService
{
    private readonly IMediator _mediator;

    public OrganizerProfileService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<SingleResponse<OrganizerProfileResponseDto>> CreateAsync(OrganizerProfileRequestDto input, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new CreateOrganizerProfileCommand(input), cancellationToken);
    }
    public async Task<SingleResponse<OrganizerProfileResponseDto>> UpdateAsync(Guid id, OrganizerProfileRequestDto input, CancellationToken cancellationToken)
    {
      return  await _mediator.Send(new UpdateOrganizerProfileCommand(id, input), cancellationToken);
    }

    public async Task<JustResponse> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new DeleteOrganizerProfileCommand(id), cancellationToken);
    }

    public async Task<SingleResponse<OrganizerProfileResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetOrganizerProfileByIdQuery(id), cancellationToken);
    }

    public async Task<ListResponse<OrganizerProfileResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetAllOrganizerProfilesQuery(), cancellationToken);
    }
}
