using EventModular.Shared.Dtos.Event;
using MediatR;
namespace EventModular.Server.Modules.Events.Application.Commands;

public record CreateEventCommand(EventRequestDto dto) : IRequest<EventResponseDto>;
