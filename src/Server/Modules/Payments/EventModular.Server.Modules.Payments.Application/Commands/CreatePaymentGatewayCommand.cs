using EventModular.Shared.Dtos.Payment;
using MediatR;

namespace EventModular.Server.Modules.Payments.Application.Commands;
public record CreatePaymentGatewayCommand(PaymentGatewayRequestDto dto) : IRequest<PaymentGatewayResponseDto>;

