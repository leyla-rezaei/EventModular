using EventModular.Server.Modules.Discounts.Application.Commands.DiscountRules;
using EventModular.Server.Modules.Discounts.Application.Queries.DiscountRule;
using EventModular.Shared.Constants.Response;
using EventModular.Shared.Dtos.Discounts;
using MediatR;

namespace EventModular.Server.Modules.Discounts.Infrastructure.Services;
public class DiscountRuleService
{
    private readonly IMediator _mediator;
    public DiscountRuleService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<SingleResponse<DiscountRuleDto>> CreateAsync(DiscountRuleDto input, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new CreateDiscountRuleCommand(input), cancellationToken);
    } 

    public async Task<SingleResponse<DiscountRuleDto>> UpdateAsync(Guid id, DiscountRuleDto input, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new UpdateDiscountRuleCommand(id, input), cancellationToken);
    } 

    public async Task<JustResponse> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new DeleteDiscountRuleCommand(id), cancellationToken);
    }

    public async Task<SingleResponse<DiscountRuleDto>> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetDiscountRuleQuery(id), cancellationToken);

    }
    public async Task<ListResponse<DiscountRuleDto>> GetByCampaignAsync(Guid campaignId, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetDiscountRulesByCampaignQuery(campaignId), cancellationToken);
    }  
}
