using EventModular.Shared.Constants.Response;
using EventModular.Shared.Dtos.Discounts;
using MediatR;

namespace EventModular.Server.Modules.Discounts.Application.Queries.Coupon;
public record GetAllCouponsQuery() : IRequest<ListResponse<CouponResponseDto>>;
