using EventModular.Shared.Dtos.Rate;
using FluentValidation;

namespace EventModular.Server.Modules.Rates.Application.Validations;
public class RateValidation : AbstractValidator<RateRequestDto>
{
    public RateValidation()
    {
        RuleFor(x => x.Value)
            .InclusiveBetween(1u, 5u)   // ⭐ نمونه: فقط 1 تا 5 مجاز باشه
            .WithMessage("Rate value must be between 1 and 5");
    }
}

public class CommentRateValidation : AbstractValidator<CommentRateRequestDto>
{
    public CommentRateValidation()
    {
        RuleFor(x => x.CommentId)
            .NotEmpty();
    }
}

public class CourseRateValidation : AbstractValidator<CourseRateRequestDto>
{
    public CourseRateValidation()
    {
        RuleFor(x => x.CourseId)
            .NotEmpty();
    }
}

public class EventRateValidation : AbstractValidator<EventRateRequestDto>
{
    public EventRateValidation()
    {
        RuleFor(x => x.EventId)
            .NotEmpty();
    }
}

public class PostRateValidation : AbstractValidator<PostRateRequestDto>
{
    public PostRateValidation()
    {
        RuleFor(x => x.PostId)
            .NotEmpty();
    }
}
