using EventModular.Server.Modules.Notifications.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Dtos.Notifications;
using MediatR;
using System.Text.Json;

namespace EventModular.Server.Modules.Notifications.Application.Commands;
public class CreateNotificationCommandHandler
        : IRequestHandler<CreateNotificationCommand, NotificationResponseDto>
{
    private readonly IApplicationDbContext _context;

    public CreateNotificationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<NotificationResponseDto> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
    {
        var entity = new Notification
        {
            UserId = request.dto.UserId,
            RelatedEntityType = request.dto.RelatedEntityType,
            RelatedEntityId = request.dto.RelatedEntityId,
            Type = request.dto.Type,
            IsRead = request.dto.IsRead,
            DataJson = request.dto.Data != null
                ? JsonSerializer.Serialize(request.dto.Data)
                : null,
            Localizations = request.dto.Localizations.Select(x => new NotificationLocalization
            {
                Title = x.Title,
                Message = x.Message
            }).ToList()
        };

        await _context.Set<Notification>().AddAsync(entity,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new NotificationResponseDto
        {
            Id = entity.Id,
            UserId = entity.UserId,
            RelatedEntityType = entity.RelatedEntityType,
            RelatedEntityId = entity.RelatedEntityId,
            Type = entity.Type,
            IsRead = entity.IsRead,
            Data = entity.DataJson != null
                ? JsonSerializer.Deserialize<Dictionary<string, string>>(entity.DataJson)
                : null,
            Localizations = entity.Localizations.Select(x => new NotificationLocalizationDto
            {
                Title = x.Title,
                Message = x.Message
            }).ToList()
        };
    }
}
