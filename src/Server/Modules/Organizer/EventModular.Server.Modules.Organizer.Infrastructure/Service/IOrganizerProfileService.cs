using EventModular.Shared.Constants.Response;
using EventModular.Shared.Dtos.Organizer;

namespace EventModular.Server.Modules.Organizer.Infrastructure.Service;
public interface IOrganizerProfileService
{
    Task<SingleResponse<OrganizerProfileResponseDto>> CreateAsync(OrganizerProfileRequestDto input, CancellationToken cancellationToken);
    Task<SingleResponse<OrganizerProfileResponseDto>> UpdateAsync(Guid id, OrganizerProfileRequestDto input, CancellationToken cancellationToken);
    Task<JustResponse> DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<SingleResponse<OrganizerProfileResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<ListResponse<OrganizerProfileResponseDto>> GetAllAsync(CancellationToken cancellationToken);
}


