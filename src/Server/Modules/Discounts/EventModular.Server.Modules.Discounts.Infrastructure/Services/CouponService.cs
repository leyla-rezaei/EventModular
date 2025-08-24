using EventModular.Shared.Constants.Response;
using EventModular.Shared.Dtos.Discounts;
using EventModular.Server.Modules.Discounts.Application.Commands.Coupons;
using MediatR;
using EventModular.Server.Modules.Discounts.Application.Queries.Coupon;

namespace EventModular.Server.Modules.Discounts.Infrastructure.Services;
public class CouponService
{
    private readonly IMediator _mediator;
    public CouponService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task<SingleResponse<CouponResponseDto>> Create(CouponRequestDto input, CancellationToken cancellationToken)
    {
        return _mediator.Send(new CreateCouponCommand(input), cancellationToken);
    }  

    public Task<SingleResponse<CouponResponseDto>> Update(Guid id, CouponRequestDto input, CancellationToken cancellationToken)
    {
       return _mediator.Send(new UpdateCouponCommand(id, input), cancellationToken);
    }

    public Task<JustResponse> Delete(Guid id, CancellationToken cancellationToken)
    {
        return _mediator.Send(new DeleteCouponCommand(id), cancellationToken);

    }
    public Task<SingleResponse<CouponResponseDto>> Get(Guid id, CancellationToken cancellationToken)
    {
        return _mediator.Send(new GetCouponQuery(id), cancellationToken);
    }

    public Task<ListResponse<CouponResponseDto>> GetAll(CancellationToken cancellationToken)
    {
        return _mediator.Send(new GetAllCouponsQuery(), cancellationToken);
    }
}

