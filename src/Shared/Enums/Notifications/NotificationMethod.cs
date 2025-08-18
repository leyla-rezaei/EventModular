namespace EventModular.Shared.Enums.Notifications;
[Flags]
public enum NotificationMethod
{
    None = 0,
    Email = 1 << 0,  // 1
    Sms = 1 << 1,  // 2
    PushNotification = 1 << 2,  // 4
    InApp = 1 << 3,  // 8
    VoiceCall = 1 << 4,  // 16
    Webhook = 1 << 5,  // 32
    WhatsApp = 1 << 6,  // 64
    Telegram = 1 << 7   // 128
}

