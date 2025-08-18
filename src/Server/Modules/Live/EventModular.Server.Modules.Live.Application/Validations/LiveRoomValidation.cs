using EventModular.Shared.Dtos.Live;
using FluentValidation;

namespace EventModular.Server.Modules.Live.Application.Validations;
public class LiveRoomValidation : AbstractValidator<LiveRoomRequestDto>
{
    public LiveRoomValidation()
    {
        RuleFor(x => x.ScheduledStart).GreaterThan(DateTimeOffset.UtcNow);
        RuleFor(x => x.MaxParticipants).GreaterThan(0);
    }
}
