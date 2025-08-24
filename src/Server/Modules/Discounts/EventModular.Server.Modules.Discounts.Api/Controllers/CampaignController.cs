using EventModular.Server.Modules.Discounts.Infrastructure.Services;
using EventModular.Shared.Constants.Response;
using EventModular.Shared.Dtos.Discounts;
using Microsoft.AspNetCore.Mvc;

namespace EventModular.Server.Modules.Discounts.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CampaignController : ControllerBase
{
    private readonly CampaignService _service;
    public CampaignController(CampaignService service)
    {
        _service = service;
    }


    [HttpPost]
    public Task<SingleResponse<CampaignResponseDto>> Create([FromBody] CampaignRequestDto input, CancellationToken cancellationToken)
    {
        return _service.Create(input, cancellationToken);
    }
            

    [HttpPut("{id:guid}")]
    public Task<SingleResponse<CampaignResponseDto>> Update(Guid id, [FromBody] CampaignRequestDto input, CancellationToken cancellationToken)
    {
         return _service.Update(id, input, cancellationToken);
    }


    [HttpDelete("{id:guid}")]
    public Task<JustResponse> Delete(Guid id, CancellationToken cancellationToken)
    {
        return _service.Delete(id, cancellationToken);
    }


    [HttpGet("{id:guid}")]
    public Task<SingleResponse<CampaignResponseDto>> Get(Guid id, CancellationToken cancellationToken)
    {
        return _service.Get(id, cancellationToken);
    }


    [HttpGet]
    public Task<ListResponse<CampaignResponseDto>> GetAll(CancellationToken cancellationToken)
    {
        return _service.GetAll(cancellationToken);
    }      
}
