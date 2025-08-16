using EventModular.Shared.Dtos.Order;
using MediatR;

namespace EventModular.Server.Modules.Orders.Application.Commands;
public record CreateOrderCommand(OrderRequestDto dto) : IRequest<OrderResponseDto>;
