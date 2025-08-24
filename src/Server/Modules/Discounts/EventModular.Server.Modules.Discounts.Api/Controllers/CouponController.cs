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
    public Task<SingleResponse<CouponResponseDto>> Create([FromBody] CouponRequestDto input, CancellationToken cancellationToken)
    {
        return _service.Create(input, cancellationToken);
    }
     

    [HttpPut("{id:guid}")]
    public Task<SingleResponse<CouponResponseDto>> Update(Guid id, [FromBody] CouponRequestDto input, CancellationToken cancellationToken)
    {
        return _service.Update(id, input, cancellationToken);
    }


    [HttpDelete("{id:guid}")]
    public Task<JustResponse> Delete(Guid id, CancellationToken cancellationToken)
    {
       return _service.Delete(id, cancellationToken);
    }

    [HttpGet("{id:guid}")]
    public Task<SingleResponse<CouponResponseDto>> Get(Guid id, CancellationToken cancellationToken)
    {
        return  _service.Get(id, cancellationToken);
    }

    [HttpGet]
    public Task<ListResponse<CouponResponseDto>> GetAll(CancellationToken cancellationToken)
    {
        return _service.GetAll(cancellationToken); 
    }
      
}
