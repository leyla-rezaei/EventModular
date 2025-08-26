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

    public async Task<SingleResponse<CouponResponseDto>> CreateAsync(CouponRequestDto input, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new CreateCouponCommand(input), cancellationToken);
    }  

    public async Task<SingleResponse<CouponResponseDto>> UpdateAsync(Guid id, CouponRequestDto input, CancellationToken cancellationToken)
    {
       return await _mediator.Send(new UpdateCouponCommand(id, input), cancellationToken);
    }

    public async Task<JustResponse> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new DeleteCouponCommand(id), cancellationToken);

    }
    public async Task<SingleResponse<CouponResponseDto>> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetCouponQuery(id), cancellationToken);
    }

    public async Task<ListResponse<CouponResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetAllCouponsQuery(), cancellationToken);
    }
}

