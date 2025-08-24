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

    public Task<SingleResponse<CampaignResponseDto>> Create(CampaignRequestDto input, CancellationToken cancellationToken)
    {
        return _mediator.Send(new CreateCampaignCommand(input), cancellationToken);

    }

    public Task<SingleResponse<CampaignResponseDto>> Update(Guid id, CampaignRequestDto input, CancellationToken cancellationToken)
    {
        return _mediator.Send(new UpdateCampaignCommand(id, input), cancellationToken);
    }

    public Task<JustResponse> Delete(Guid id, CancellationToken cancellationToken)
    {
        return _mediator.Send(new DeleteCampaignCommand(id), cancellationToken);

    }

    public Task<SingleResponse<CampaignResponseDto>> Get(Guid id, CancellationToken cancellationToken)
    {
        return _mediator.Send(new GetCampaignQuery(id), cancellationToken);
    }

    public Task<ListResponse<CampaignResponseDto>> GetAll(CancellationToken cancellationToken)
    {
        return _mediator.Send(new GetAllCampaignsQuery(), cancellationToken);
    }
}
