using EventModular.Shared.Dtos.Discounts;
using MediatR;

namespace EventModular.Server.Modules.Discounts.Infrastructure.Commands;
public record CreateCouponCommand(CouponRequestDto dto) : IRequest<CouponResponseDto>;
