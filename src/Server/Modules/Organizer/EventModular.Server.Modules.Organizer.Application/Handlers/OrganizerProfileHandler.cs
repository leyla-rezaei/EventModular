using EventModular.Server.Modules.Organizer.Application.Commands;
using EventModular.Server.Modules.Organizer.Application.Queries;
using EventModular.Server.Modules.Organizer.Domain.Entities;
using EventModular.Shared.Base.Repositories;
using EventModular.Shared.Constants.Response;
using EventModular.Shared.Dtos.Organizer;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventModular.Server.Modules.Organizer.Application.Handlers;

public class OrganizerProfileHandler :
    IRequestHandler<CreateOrganizerProfileCommand, SingleResponse<OrganizerProfileResponseDto>>,
    IRequestHandler<UpdateOrganizerProfileCommand, SingleResponse<OrganizerProfileResponseDto>>,
    IRequestHandler<DeleteOrganizerProfileCommand, JustResponse>,
    IRequestHandler<GetOrganizerProfileByIdQuery, SingleResponse<OrganizerProfileResponseDto>>,
    IRequestHandler<GetAllOrganizerProfilesQuery, ListResponse<OrganizerProfileResponseDto>>
{
    private readonly IBaseRepository<OrganizerProfile> _repository;

    public OrganizerProfileHandler(IBaseRepository<OrganizerProfile> repository)
    {
        _repository = repository;
    }

    public async Task<SingleResponse<OrganizerProfileResponseDto>> Handle(CreateOrganizerProfileCommand request, CancellationToken cancellationToken)
    {
        var entity = request.dto.Adapt<OrganizerProfile>();

        if (request.dto.Localizations?.Any() == true)
            entity.Localizations = request.dto.Localizations.Adapt<List<OrganizerProfileLocalization>>();

        if (request.dto.SupportedCurrencies?.Any() == true)
            entity.SupportedCurrencies = request.dto.SupportedCurrencies.Adapt<List<OrganizerSupportedCurrency>>();

        await _repository.Create(entity, cancellationToken);

        return SingleResponse<OrganizerProfileResponseDto>.Success(entity.Adapt<OrganizerProfileResponseDto>());
    }

    public async Task<SingleResponse<OrganizerProfileResponseDto>> Handle(UpdateOrganizerProfileCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetById(request.Id, cancellationToken);
        if (entity == null) return ResponseStatus.NotFound;

        request.dto.Adapt(entity);

        if (request.dto.Localizations?.Any() == true)
            entity.Localizations = request.dto.Localizations.Adapt<List<OrganizerProfileLocalization>>();

        if (request.dto.SupportedCurrencies?.Any() == true)
            entity.SupportedCurrencies = request.dto.SupportedCurrencies.Adapt<List<OrganizerSupportedCurrency>>();

        await _repository.Update(entity.Id, entity, cancellationToken);

        return SingleResponse<OrganizerProfileResponseDto>.Success(entity.Adapt<OrganizerProfileResponseDto>());
    }

    public async Task<JustResponse> Handle(DeleteOrganizerProfileCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetById(request.Id, cancellationToken);
        if (entity == null) return ResponseStatus.NotFound;

        await _repository.Delete(entity.Id, cancellationToken);
        return ResponseStatus.Success;
    }

    public async Task<SingleResponse<OrganizerProfileResponseDto>> Handle(GetOrganizerProfileByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAll()
            .Include(x => x.Localizations)
            .Include(x => x.SupportedCurrencies)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return entity == null
            ? ResponseStatus.NotFound
            : SingleResponse<OrganizerProfileResponseDto>.Success(entity.Adapt<OrganizerProfileResponseDto>());
    }

    public async Task<ListResponse<OrganizerProfileResponseDto>> Handle(GetAllOrganizerProfilesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAll()
            .Include(x => x.Localizations)
            .Include(x => x.SupportedCurrencies)
            .ToListAsync(cancellationToken);

        return ListResponse<OrganizerProfileResponseDto>.Success(entities.Adapt<List<OrganizerProfileResponseDto>>());
    }
}
