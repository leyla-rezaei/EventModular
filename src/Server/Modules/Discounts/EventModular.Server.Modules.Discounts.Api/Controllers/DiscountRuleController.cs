using EventModular.Server.Modules.Discounts.Infrastructure.Services;
using EventModular.Shared.Constants.Response;
using EventModular.Shared.Dtos.Discounts;
using Microsoft.AspNetCore.Mvc;

namespace EventModular.Server.Modules.Discounts.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DiscountRuleController : ControllerBase
{
    private readonly DiscountRuleService _service;
    public DiscountRuleController(DiscountRuleService service)
    {
        _service = service;
    }

    [HttpPost]
    public Task<SingleResponse<DiscountRuleDto>> Create([FromBody] DiscountRuleDto input, CancellationToken cancellationToken)
    {
        return _service.Create(input, cancellationToken);
    }

    [HttpPut("{id:guid}")]
    public Task<SingleResponse<DiscountRuleDto>> Update(Guid id, [FromBody] DiscountRuleDto input, CancellationToken cancellationToken)
    {
        return _service.Update(id, input, cancellationToken);
    }

    [HttpDelete("{id:guid}")]
    public Task<JustResponse> Delete(Guid id, CancellationToken cancellationToken)
    {
        return _service.Delete(id, cancellationToken);
    }

    [HttpGet("{id:guid}")]
    public Task<SingleResponse<DiscountRuleDto>> Get(Guid id, CancellationToken cancellationToken)
    {
        return _service.Get(id, cancellationToken);
    }

    [HttpGet("campaign/{campaignId:guid}")]
    public Task<ListResponse<DiscountRuleDto>> GetByCampaign(Guid campaignId, CancellationToken cancellationToken)
    {
        return _service.GetByCampaign(campaignId, cancellationToken);
    }
}
