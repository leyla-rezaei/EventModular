using EventModular.Server.Modules.Discounts.Infrastructure.Services;
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
    public async Task<IActionResult> Create([FromBody] DiscountRuleDto input, CancellationToken cancellationToken)
    {
        var result = await _service.CreateAsync(input, cancellationToken);;

        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] DiscountRuleDto input, CancellationToken cancellationToken)
    {
        var result = await _service.UpdateAsync(id, input, cancellationToken);

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await _service.DeleteAsync(id, cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var result = await _service.GetAsync(id, cancellationToken);

        return Ok(result);
    }

    [HttpGet("campaign/{campaignId:guid}")]
    public async Task<IActionResult> GetByCampaign(Guid campaignId, CancellationToken cancellationToken)
    {
        var result = await _service.GetByCampaignAsync(campaignId, cancellationToken);

        return Ok(result);
    }
}
