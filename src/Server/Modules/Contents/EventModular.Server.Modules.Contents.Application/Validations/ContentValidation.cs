using EventModular.Shared.Dtos.Content;
using FluentValidation;

namespace EventModular.Server.Modules.Contents.Application.Validations;
public class ContentValidation : AbstractValidator<ContentRequestDto>
{
    public ContentValidation()
    {
        RuleForEach(x => x.Localizations)
            .SetValidator(new ContentLocalizationValidation());
    }
}

public class PostContentValidation : AbstractValidator<PostContentRequestDto>
{
    public PostContentValidation()
    {
        Include(new ContentValidation());

        RuleForEach(x => x.Localizations)
            .SetValidator(new PostContentLocalizationValidation());
    }
}

public class CourseLessonContentValidation : AbstractValidator<CourseLessonContentRequestDto>
{
    public CourseLessonContentValidation()
    {
        Include(new ContentValidation());

        RuleFor(x => x.CourseLessonId)
            .NotEmpty();
    }
}

public class EventContentValidation : AbstractValidator<EventContentRequestDto>
{
    public EventContentValidation()
    {
        Include(new ContentValidation());

        RuleFor(x => x.EventId)
            .NotEmpty();
            
    }
}        


public class ContentLocalizationValidation : AbstractValidator<ContentLocalizationDto>
{
    public ContentLocalizationValidation()
    {
        RuleFor(x => x.Key)
            .NotEmpty();

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("title is required.")
            .MaximumLength(250);

        RuleFor(x => x.Body)
            .NotEmpty().WithMessage("body is required.");
    }
}

public class PostContentLocalizationValidation : AbstractValidator<PostContentLocalizationDto>
{
    public PostContentLocalizationValidation()
    {
        RuleFor(x => x.Excerpt)
            .MaximumLength(500).When(x => !string.IsNullOrWhiteSpace(x.Excerpt));
    }
}
