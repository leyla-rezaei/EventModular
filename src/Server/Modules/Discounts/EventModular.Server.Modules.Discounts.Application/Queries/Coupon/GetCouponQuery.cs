using EventModular.Shared.Constants.Response;
using EventModular.Shared.Dtos.Discounts;
using MediatR;

namespace EventModular.Server.Modules.Discounts.Application.Queries.Coupon;
public record GetCouponQuery(Guid Id) : IRequest<SingleResponse<CouponResponseDto>>;
