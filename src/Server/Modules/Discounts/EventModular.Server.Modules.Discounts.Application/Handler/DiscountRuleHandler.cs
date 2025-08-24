using EventModular.Server.Modules.Discounts.Application.Commands.DiscountRules;
using EventModular.Server.Modules.Discounts.Application.Queries.DiscountRule;
using EventModular.Server.Modules.Discounts.Domain.Entities;
using EventModular.Shared.Base.Repositories;
using EventModular.Shared.Constants.Response;
using EventModular.Shared.Dtos.Discounts;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventModular.Server.Modules.Discounts.Application.Handler;
public class DiscountRuleHandler :
    IRequestHandler<CreateDiscountRuleCommand, SingleResponse<DiscountRuleDto>>,
    IRequestHandler<UpdateDiscountRuleCommand, SingleResponse<DiscountRuleDto>>,
    IRequestHandler<DeleteDiscountRuleCommand, JustResponse>,
    IRequestHandler<GetDiscountRuleQuery, SingleResponse<DiscountRuleDto>>,
    IRequestHandler<GetDiscountRulesByCampaignQuery, ListResponse<DiscountRuleDto>>
{
    private readonly IBaseRepository<DiscountRule> _repository;

    public DiscountRuleHandler(IBaseRepository<DiscountRule> repository)
    {
        _repository = repository;
    }

    public async Task<SingleResponse<DiscountRuleDto>> Handle(CreateDiscountRuleCommand request, CancellationToken cancellationToken)
    {
        var entity = request.dto.Adapt<DiscountRule>();
        await _repository.Create(entity, cancellationToken);
        return SingleResponse<DiscountRuleDto>.Success(entity.Adapt<DiscountRuleDto>());
    }

    public async Task<SingleResponse<DiscountRuleDto>> Handle(UpdateDiscountRuleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetById(request.Id, cancellationToken);
        if (entity == null) return ResponseStatus.NotFound;

        request.dto.Adapt(entity);
        await _repository.Update(entity.Id, entity, cancellationToken);
        return SingleResponse<DiscountRuleDto>.Success(entity.Adapt<DiscountRuleDto>());
    }

    public async Task<JustResponse> Handle(DeleteDiscountRuleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetById(request.Id, cancellationToken);
        if (entity == null) return ResponseStatus.NotFound;

        await _repository.Delete(request.Id, cancellationToken);
        return ResponseStatus.Success;
    }

    public async Task<SingleResponse<DiscountRuleDto>> Handle(GetDiscountRuleQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetById(request.Id, cancellationToken);
        return entity == null ? ResponseStatus.NotFound : SingleResponse<DiscountRuleDto>.Success(entity.Adapt<DiscountRuleDto>());
    }

    public async Task<ListResponse<DiscountRuleDto>> Handle(GetDiscountRulesByCampaignQuery request, CancellationToken cancellationToken)
    {
        var rules = await _repository.GetAll()
            .Where(x => x.CampaignId == request.CampaignId)
            .ToListAsync(cancellationToken);

        return ListResponse<DiscountRuleDto>.Success(rules.Adapt<List<DiscountRuleDto>>());
    }

}
