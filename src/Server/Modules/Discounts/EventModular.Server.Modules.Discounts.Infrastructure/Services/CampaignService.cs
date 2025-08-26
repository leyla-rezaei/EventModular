using EventModular.Server.Modules.Discounts.Application.Commands.Campaigns;
using EventModular.Server.Modules.Discounts.Application.Queries.Campaign;
using EventModular.Shared.Constants.Response;
using EventModular.Shared.Dtos.Discounts;
using MediatR;

namespace EventModular.Server.Modules.Discounts.Infrastructure.Services;
public class CampaignService
{
    private readonly IMediator _mediator;
    public CampaignService(IMediator mediator)
    {  
        _mediator = mediator;
    }

    public async Task<SingleResponse<CampaignResponseDto>> CreateAsync(CampaignRequestDto input, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new CreateCampaignCommand(input), cancellationToken);
    }

    public async Task<SingleResponse<CampaignResponseDto>> UpdateAsync(Guid id, CampaignRequestDto input, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new UpdateCampaignCommand(id, input), cancellationToken);
    }

    public async Task<JustResponse> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new DeleteCampaignCommand(id), cancellationToken);

    }

    public async Task<SingleResponse<CampaignResponseDto>> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetCampaignQuery(id), cancellationToken);
    }

    public async Task<ListResponse<CampaignResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetAllCampaignsQuery(), cancellationToken);
    }
}
