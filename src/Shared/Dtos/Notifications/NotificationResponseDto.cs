using EventModular.Shared.Enums.Notifications;

namespace EventModular.Shared.Dtos.Notifications;
public class NotificationResponseDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public NotificationEntityType RelatedEntityType { get; set; }
    public Guid? RelatedEntityId { get; set; }
    public NotificationType Type { get; set; }
    public bool IsRead { get; set; }

    public Dictionary<string, string>? Data { get; set; }

    public List<NotificationLocalizationDto> Localizations { get; set; } = new();
}
