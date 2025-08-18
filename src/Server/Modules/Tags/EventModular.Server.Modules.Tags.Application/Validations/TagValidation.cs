using EventModular.Shared.Dtos.Tag;
using FluentValidation;

namespace EventModular.Server.Modules.Tags.Application.Validations;
public class TagValidation : AbstractValidator<TagRequestDto>
{
    public TagValidation()
    {
        RuleFor(x => x.TagType)
            .IsInEnum();

        RuleForEach(x => x.Localizations)
            .SetValidator(new TagLocalizationValidation());
    }
}

public class TagLocalizationValidation : AbstractValidator<TagLocalizationDto>
{
    public TagLocalizationValidation()
    {
        RuleFor(x => x.TagName)
            .NotEmpty().WithMessage("tag name is required")
            .MaximumLength(100).WithMessage("tag name must not exceed 100 characters");
    }
}

public class PostTagValidation : AbstractValidator<PostTagRequestDto>
{
    public PostTagValidation()
    {
        RuleFor(x => x.PostId)
            .NotEmpty();

        RuleFor(x => x.TagId)
            .NotEmpty();
    }
}

public class CourseTagValidation : AbstractValidator<CourseTagRequestDto>
{
    public CourseTagValidation()
    {
        RuleFor(x => x.CourseId)
            .NotEmpty();

        RuleFor(x => x.TagId)
            .NotEmpty();
    }
}

public class EventTagValidation : AbstractValidator<EventTagRequestDto>
{
    public EventTagValidation()
    {
        RuleFor(x => x.EventId)
            .NotEmpty();

        RuleFor(x => x.TagId)
            .NotEmpty();
    }
}
