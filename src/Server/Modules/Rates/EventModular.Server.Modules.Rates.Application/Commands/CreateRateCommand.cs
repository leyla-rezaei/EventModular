using EventModular.Shared.Dtos.Rate;
using MediatR;

namespace EventModular.Server.Modules.Rates.Application.Commands;
public record CreateRateCommand(RateRequestDto dto) : IRequest<RateResponseDto>;
