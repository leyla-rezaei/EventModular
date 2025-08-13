using EventModular.Shared.Dtos.Notifications;
using MediatR;

namespace EventModular.Server.Modules.Notifications.Application.Commands;
public record CreateNotificationCommand(NotificationRequestDto dto)
        : IRequest<NotificationResponseDto>;
