using EventModular.Shared.Dtos.Live;
using FluentValidation;

namespace EventModular.Server.Modules.Live.Application.Validations;

public class LivePollValidation : AbstractValidator<LivePollRequestDto>
{
    public LivePollValidation()
    {
        RuleFor(x => x.Question).NotEmpty().MaximumLength(300);
        RuleFor(x => x.Options).NotEmpty().Must(o => o.Count >= 2).WithMessage("Poll must have at least 2 options.");
    }
}
