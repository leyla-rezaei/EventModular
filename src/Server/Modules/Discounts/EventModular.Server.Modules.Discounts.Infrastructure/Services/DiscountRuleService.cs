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

    public Task<SingleResponse<DiscountRuleDto>> Create(DiscountRuleDto input, CancellationToken cancellationToken)
    {
        return _mediator.Send(new CreateDiscountRuleCommand(input), cancellationToken);
    } 

    public Task<SingleResponse<DiscountRuleDto>> Update(Guid id, DiscountRuleDto input, CancellationToken cancellationToken)
    {
        return _mediator.Send(new UpdateDiscountRuleCommand(id, input), cancellationToken);
    } 

    public Task<JustResponse> Delete(Guid id, CancellationToken cancellationToken)
    {
        return _mediator.Send(new DeleteDiscountRuleCommand(id), cancellationToken);
    }

    public Task<SingleResponse<DiscountRuleDto>> Get(Guid id, CancellationToken cancellationToken)
    {
        return _mediator.Send(new GetDiscountRuleQuery(id), cancellationToken);

    }
    public Task<ListResponse<DiscountRuleDto>> GetByCampaign(Guid campaignId, CancellationToken cancellationToken)
    {
        return _mediator.Send(new GetDiscountRulesByCampaignQuery(campaignId), cancellationToken);
    }  
}
