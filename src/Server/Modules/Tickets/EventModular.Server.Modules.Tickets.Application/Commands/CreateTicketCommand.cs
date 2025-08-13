using EventModular.Shared.Dtos.Tickets;
using MediatR;

namespace EventModular.Server.Modules.Tickets.Application.Commands;

public record CreateTicketCommand(TicketRequestDto dto) : IRequest<TicketResponseDto>;
