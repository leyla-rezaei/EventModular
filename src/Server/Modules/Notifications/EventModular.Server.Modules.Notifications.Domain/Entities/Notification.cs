using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Notifications;

namespace EventModular.Server.Modules.Notifications.Domain.Entities;
[Table(nameof(Notification), Schema = SchemaConsts.Notification)]
public class Notification : BaseEntity
{
    public Guid UserId { get; set; }

    public Guid? RelatedOwnerTypeId { get; set; }
    public NotificationOwnerType RelatedOwnerType { get; set; }

    public NotificationMethod Method { get; set; } 
    public NotificationType Type { get; set; }

    public bool IsRead { get; set; }

    /// <summary>
    /// داده اضافی برای اعلان به صورت JSON
    /// </summary>
    public string? DataJson { get; set; }

    public ICollection<NotificationLocalization> Localizations { get; set; } = new List<NotificationLocalization>();
}

