using EventModular.Server.Modules.Organizer.Infrastructure.Service;
using EventModular.Shared.Dtos.Organizer;
using Microsoft.AspNetCore.Mvc;

namespace EventModular.Server.Modules.Organizer.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class OrganizerProfileController : ControllerBase
{
    private readonly IOrganizerProfileService _service;

    public OrganizerProfileController(IOrganizerProfileService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrganizerProfileRequestDto input, CancellationToken cancellationToken)
    {
        var result = await _service.CreateAsync(input, cancellationToken);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] OrganizerProfileRequestDto input, CancellationToken cancellationToken)
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
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _service.GetByIdAsync(id, cancellationToken);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _service.GetAllAsync(cancellationToken);
        return Ok(result);
    }
}

