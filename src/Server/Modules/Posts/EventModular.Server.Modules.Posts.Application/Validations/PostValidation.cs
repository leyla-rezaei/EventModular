using EventModular.Shared.Dtos.Posts;
using FluentValidation;

namespace EventModular.Server.Modules.Posts.Application.Validations;
public class PostValidation : AbstractValidator<PostRequestDto>
{
    public PostValidation()
    {
        RuleFor(x => x.WriterId).NotEmpty();
        RuleFor(x => x.PostFormat).IsInEnum();
        RuleFor(x => x.PostType).IsInEnum();
        RuleForEach(x => x.Localizations!).SetValidator(new PostLocalizationValidation());
    }
}
public class PostLocalizationValidation : AbstractValidator<PostLocalizationDto>
{
    public PostLocalizationValidation()
    {
        RuleFor(x => x.Key).NotEmpty();
        RuleFor(x => x.Slug).NotEmpty();
    }
}
