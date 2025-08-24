using EventModular.Server.Modules.Discounts.Application.Commands.Coupons;
using EventModular.Server.Modules.Discounts.Application.Queries.Coupon;
using EventModular.Server.Modules.Discounts.Domain.Entities;
using EventModular.Shared.Base.Repositories;
using EventModular.Shared.Constants.Response;
using EventModular.Shared.Dtos.Discounts;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace EventModular.Server.Modules.Discounts.Application.Handler;

public class CouponHandler :
    IRequestHandler<CreateCouponCommand, SingleResponse<CouponResponseDto>>,
    IRequestHandler<UpdateCouponCommand, SingleResponse<CouponResponseDto>>,
    IRequestHandler<DeleteCouponCommand, JustResponse>,
    IRequestHandler<GetCouponQuery, SingleResponse<CouponResponseDto>>,
    IRequestHandler<GetAllCouponsQuery, ListResponse<CouponResponseDto>>
{
    private readonly IBaseRepository<Coupon> _repository;

    public CouponHandler(IBaseRepository<Coupon> repository)
    {
        _repository = repository;
    }

    public async Task<SingleResponse<CouponResponseDto>> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
    {
        var entity = request.dto.Adapt<Coupon>();

        if (request.dto.Localizations?.Any() == true)
            entity.Localizations = request.dto.Localizations.Adapt<List<CouponLocalization>>();

        await _repository.Create(entity, cancellationToken);
        return SingleResponse<CouponResponseDto>.Success(entity.Adapt<CouponResponseDto>());
    }

    public async Task<SingleResponse<CouponResponseDto>> Handle(UpdateCouponCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetById(request.Id, cancellationToken);
        if (entity == null) return ResponseStatus.NotFound;

        request.dto.Adapt(entity);
        if (request.dto.Localizations?.Any() == true)
            entity.Localizations = request.dto.Localizations.Adapt<List<CouponLocalization>>();

        await _repository.Update(entity.Id, entity, cancellationToken);
        return SingleResponse<CouponResponseDto>.Success(entity.Adapt<CouponResponseDto>());
    }

    public async Task<JustResponse> Handle(DeleteCouponCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetById(request.Id, cancellationToken);
        if (entity == null) return ResponseStatus.NotFound;

        await _repository.Delete(request.Id, cancellationToken);
        return ResponseStatus.Success;
    }

    public async Task<SingleResponse<CouponResponseDto>> Handle(GetCouponQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAll()
            .Include(x => x.Localizations)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return entity == null ? ResponseStatus.NotFound : SingleResponse<CouponResponseDto>.Success(entity.Adapt<CouponResponseDto>());
    }

    public async Task<ListResponse<CouponResponseDto>> Handle(GetAllCouponsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAll()
            .Include(x => x.Localizations)
            .ToListAsync(cancellationToken);

        return ListResponse<CouponResponseDto>.Success(entities.Adapt<List<CouponResponseDto>>());
    }
}
