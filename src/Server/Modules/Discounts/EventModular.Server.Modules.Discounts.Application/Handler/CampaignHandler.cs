using EventModular.Server.Modules.Discounts.Application.Commands.Campaigns;
using EventModular.Server.Modules.Discounts.Application.Queries.Campaign;
using EventModular.Server.Modules.Discounts.Domain.Entities;
using EventModular.Shared.Base.Repositories;
using EventModular.Shared.Constants.Response;
using EventModular.Shared.Dtos.Discounts;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventModular.Server.Modules.Discounts.Application.Handler;
public class CampaignHandler :
    IRequestHandler<CreateCampaignCommand, SingleResponse<CampaignResponseDto>>,
    IRequestHandler<UpdateCampaignCommand, SingleResponse<CampaignResponseDto>>,
    IRequestHandler<DeleteCampaignCommand, JustResponse>,
    IRequestHandler<GetCampaignQuery, SingleResponse<CampaignResponseDto>>,
    IRequestHandler<GetAllCampaignsQuery, ListResponse<CampaignResponseDto>>
{
    private readonly IBaseRepository<Campaign> _repository;

    public CampaignHandler(IBaseRepository<Campaign> repository)
    {
        _repository = repository;
    }

    public async Task<SingleResponse<CampaignResponseDto>> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
    {
        var entity = request.dto.Adapt<Campaign>();

        if (request.dto.Localizations?.Any() == true)
            entity.Localizations = request.dto.Localizations.Adapt<List<CampaignLocalization>>();

        if (request.dto.Rules?.Any() == true)
            entity.Rules = request.dto.Rules.Adapt<List<DiscountRule>>();

        await _repository.Create(entity, cancellationToken);
        return SingleResponse<CampaignResponseDto>.Success(entity.Adapt<CampaignResponseDto>());
    }

    public async Task<SingleResponse<CampaignResponseDto>> Handle(UpdateCampaignCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetById(request.Id, cancellationToken);
        if (entity == null) return ResponseStatus.NotFound;

        request.dto.Adapt(entity);
        if (request.dto.Localizations?.Any() == true)
            entity.Localizations = request.dto.Localizations.Adapt<List<CampaignLocalization>>();

        if (request.dto.Rules?.Any() == true)
            entity.Rules = request.dto.Rules.Adapt<List<DiscountRule>>();

        await _repository.Update(entity.Id, entity, cancellationToken);
        return SingleResponse<CampaignResponseDto>.Success(entity.Adapt<CampaignResponseDto>());
    }

    public async Task<JustResponse> Handle(DeleteCampaignCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetById(request.Id, cancellationToken);
        if (entity == null) return ResponseStatus.NotFound;

        await _repository.Delete(request.Id, cancellationToken);
        return ResponseStatus.Success;
    }

    public async Task<SingleResponse<CampaignResponseDto>> Handle(GetCampaignQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAll()
            .Include(x => x.Localizations)
            .Include(x => x.Rules)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return entity == null ? ResponseStatus.NotFound : SingleResponse<CampaignResponseDto>.Success(entity.Adapt<CampaignResponseDto>());
    }

    public async Task<ListResponse<CampaignResponseDto>> Handle(GetAllCampaignsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAll()
            .Include(x => x.Localizations)
            .Include(x => x.Rules)
            .ToListAsync(cancellationToken);

        return ListResponse<CampaignResponseDto>.Success(entities.Adapt<List<CampaignResponseDto>>());
    }
}
