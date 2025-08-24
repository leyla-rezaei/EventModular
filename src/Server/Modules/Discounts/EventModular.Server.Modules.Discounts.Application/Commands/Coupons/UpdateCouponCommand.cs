using EventModular.Shared.Constants.Response;
using EventModular.Shared.Dtos.Discounts;
using MediatR;

namespace EventModular.Server.Modules.Discounts.Application.Commands.Coupons;
public record UpdateCouponCommand(Guid Id, CouponRequestDto dto) : IRequest<SingleResponse<CouponResponseDto>>;

