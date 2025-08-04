using EventModular.Shared.Dtos.PushNotification;

namespace EventModular.Client.Maui.Platforms.Windows.Services;

public partial class WindowsPushNotificationService : PushNotificationServiceBase
{
    public override Task<PushNotificationSubscriptionDto?> GetSubscription(CancellationToken cancellationToken) => 
        throw new NotImplementedException();

    public override Task RequestPermission(CancellationToken cancellationToken) =>
        throw new NotImplementedException();
}
