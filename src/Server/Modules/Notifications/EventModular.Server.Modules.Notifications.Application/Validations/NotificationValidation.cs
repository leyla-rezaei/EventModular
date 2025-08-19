using EventModular.Shared.Dtos.Notifications;
using FluentValidation;

namespace EventModular.Server.Modules.Notifications.Application.Validations;
public class NotificationValidation : AbstractValidator<NotificationRequestDto>
{
    public NotificationValidation()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Method).NotEmpty();

        RuleForEach(x => x.Localizations)
            .SetValidator(new NotificationLocalizationValidation());
    }
}

public class NotificationLocalizationValidation : AbstractValidator<NotificationLocalizationDto>
{ 
    public  NotificationLocalizationValidation()
    {
        RuleFor(x => x.Message).NotEmpty(); 
    }
}
