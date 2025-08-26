using EventModular.Server.Modules.Discounts.Infrastructure.Services;
using EventModular.Shared.Constants.Response;
using EventModular.Shared.Dtos.Discounts;
using Microsoft.AspNetCore.Mvc;

namespace EventModular.Server.Modules.Discounts.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CouponController : ControllerBase
{
    private readonly CouponService _service;

    public CouponController(CouponService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CouponRequestDto input, CancellationToken cancellationToken)
    {
        var result = await _service.CreateAsync(input, cancellationToken);;

        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CouponRequestDto input, CancellationToken cancellationToken)
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

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _service.GetAllAsync(cancellationToken);

        return Ok(result);
    }
}
