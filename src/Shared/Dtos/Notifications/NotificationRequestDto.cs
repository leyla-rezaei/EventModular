using EventModular.Shared.Enums.Notifications;

namespace EventModular.Shared.Dtos.Notifications;
public class NotificationRequestDto
{
    public Guid UserId { get; set; }
    public Guid? RelatedOwnerTypeId { get; set; }
    public NotificationOwnerType RelatedOwnerType { get; set; }

    public NotificationMethod Method { get; set; }
    public NotificationType Type { get; set; }
    public bool IsRead { get; set; }

    public Dictionary<string, string>? Data { get; set; }

    public List<NotificationLocalizationDto>? Localizations { get; set; } 
}

public class NotificationLocalizationDto
{
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}
