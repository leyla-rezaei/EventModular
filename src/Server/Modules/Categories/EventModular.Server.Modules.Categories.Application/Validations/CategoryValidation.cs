using EventModular.Shared.Dtos.Category;
using FluentValidation;

namespace EventModular.Server.Modules.Categories.Application.Validations;

    public class CategoryValidation : AbstractValidator<CategoryRequestDto>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.CategoryType)
                .IsInEnum()
                .WithMessage("Invalid category type.");

            RuleForEach(x => x.Localizations)
                .SetValidator(new CategoryLocalizationValidation());
        }

        public class CategoryLocalizationValidation : AbstractValidator<CategoryLocalizationDto>
        {
            public CategoryLocalizationValidation()
            {
                RuleFor(x => x.Key)
                    .NotEmpty().WithMessage("Key is required.")
                    .MaximumLength(50).WithMessage("Key cannot be longer than 50 characters.");

                RuleFor(x => x.Title)
                    .NotEmpty().WithMessage("Title is required.")
                    .MaximumLength(200).WithMessage("Title cannot be longer than 200 characters.");

                RuleFor(x => x.Slug)
                    .NotEmpty().WithMessage("Slug is required.")
                    .Matches("^[a-z0-9-]+$").WithMessage("Slug can only contain lowercase letters, numbers, and hyphens.")
                    .MaximumLength(200).WithMessage("Slug cannot be longer than 200 characters.");

                RuleFor(x => x.Description)
                    .MaximumLength(500).WithMessage("Description cannot be longer than 500 characters.")
                    .When(x => !string.IsNullOrEmpty(x.Description));
            }
        }
    }
