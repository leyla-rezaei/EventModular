using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Notifications.Domain.Entities;
[Table(nameof(NotificationLocalization), Schema = SchemaConsts.Localization)]
public class NotificationLocalization : BaseLocalization
{
    public Guid NotificationId { get; set; }
    public Notification Notification { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}
