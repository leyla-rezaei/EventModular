using EventModular.Shared.Dtos.Media;
using FluentValidation;

namespace EventModular.Server.Modules.Media.Application.Validations;

public class MediaFileValidation : AbstractValidator<MediaFileRequestDto>
{
    public MediaFileValidation()
    {
        RuleFor(x => x.FileName)
            .NotEmpty().WithMessage("file name is required")
            .MaximumLength(255);

        RuleFor(x => x.FileSize)
            .GreaterThan(0).WithMessage("file size must be greater than zero");

        RuleFor(x => x.StoragePath)
            .NotEmpty();

        RuleForEach(x => x.Localizations)
            .SetValidator(new MediaFileLocalizationValidation());
    }
}

public class MediaFileLocalizationValidation : AbstractValidator<MediaFileLocalizationDto>
{
    public MediaFileLocalizationValidation()
    {
        RuleFor(x => x.key)
            .NotEmpty();

        RuleFor(x => x.DisplayName)
            .NotEmpty()
            .MaximumLength(255);
    }
}


public class PostMediaValidation : AbstractValidator<PostMediaRequestDto>
{
    public PostMediaValidation()
    {
        Include(new MediaFileValidation());

        RuleFor(x => x.PostId)
            .NotEmpty();

        RuleForEach(x => x.Localizations)
            .SetValidator(new PostMediaLocalizationValidation());
    }
}

public class PostMediaLocalizationValidation : AbstractValidator<PostMediaLocalizationDto>
{
    public PostMediaLocalizationValidation()
    {
       
        RuleFor(x => x.Title)
            .NotEmpty();

        RuleFor(x => x.Alt)
            .NotEmpty()
            .MaximumLength(255);
    }
}

public class CommentMediaValidation : AbstractValidator<CommentMediaRequestDto>
{
    public CommentMediaValidation()
    {
        Include(new MediaFileValidation());

        RuleFor(x => x.CommentId)
            .NotEmpty();
    }
}

public class EventMediaValidation : AbstractValidator<EventMediaRequestDto>
{
    public EventMediaValidation()
    {
        Include(new MediaFileValidation());

        RuleFor(x => x.EventId)
            .NotEmpty();

        RuleForEach(x => x.Localizations)
            .SetValidator(new EventMediaLocalizationValidation());
    }
}

public class EventMediaLocalizationValidation : AbstractValidator<EventMediaLocalizationDto>
{
    public EventMediaLocalizationValidation()
    {
        RuleFor(x => x.Title)
            .NotEmpty();

        RuleFor(x => x.Alt)
            .NotEmpty();
    }
}
