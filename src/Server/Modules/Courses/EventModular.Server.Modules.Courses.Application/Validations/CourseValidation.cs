using EventModular.Shared.Dtos.Course;
using FluentValidation;

namespace EventModular.Server.Modules.Courses.Application.Validations;

public class CourseValidation : AbstractValidator<CourseRequestDto>
{
    public CourseValidation()
    {
        RuleFor(x => x.OrganizerId).NotEmpty();
        RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
        RuleForEach(x => x.Localizations!).SetValidator(new CourseLocalizationValidation());
        RuleForEach(x => x.Sections!).SetValidator(new CourseSectionValidation());
    }
}

public class CourseLocalizationValidation : AbstractValidator<CourseLocalizationDto>
{
    public CourseLocalizationValidation()
    {
        RuleFor(x => x.Key).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
    }
}

public class CourseSectionValidation : AbstractValidator<CourseSectionRequestDto>
{
    public CourseSectionValidation()
    {
        RuleFor(x => x.Index.Value)
           .GreaterThanOrEqualTo(0)
           .WithMessage("Index cannot be negative.");

        RuleForEach(x => x.Localizations!).SetValidator(new CourseSectionLocalizationValidation());
        RuleForEach(x => x.Lessons!).SetValidator(new CourseLessonValidation());
    }
}
public class CourseSectionLocalizationValidation : AbstractValidator<CourseSectionLocalizationDto>
{
    public CourseSectionLocalizationValidation()
    {
        RuleFor(x => x.Key).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
    }
}


public class CourseLessonValidation : AbstractValidator<CourseLessonRequestDto>
{
    public CourseLessonValidation()
    {
        RuleFor(x => x.Index.Value)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Index cannot be negative.");
        RuleForEach(x => x.Localizations!).SetValidator(new CourseLessonLocalizationValidation());
    }
}
 
public class CourseLessonLocalizationValidation : AbstractValidator<CourseLessonLocalizationDto>
{
    public CourseLessonLocalizationValidation()
    {
        RuleFor(x => x.Key).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
    }
}
