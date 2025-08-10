using FluentValidation;
using EventModular.Shared.Dtos.Comments;

namespace EventModular.Server.Modules.Comments.Application.Validations;

public class CommentValidation : AbstractValidator<CommentRequestDto>
{
    public CommentValidation()
    {

        RuleFor(comment => comment.UserId)
            .NotNull().WithMessage("user id cannot be null.");

        RuleFor(x => x.CommentType)
            .IsInEnum();

        RuleFor(x => x.Visibility)
            .IsInEnum();

        RuleFor(comment => comment.ReplyedToCommentId)
            .Must((comment, replyId) => replyId != comment.UserId)
            .WithMessage("cannot reply to your own comment.");

        RuleForEach(x => x.Localizations)
        .SetValidator(new CommentLocalizationValidation());

    }

    public class EventCommentValidation : AbstractValidator<EventCommentRequestDto>
    {
        public EventCommentValidation() 
        {
            RuleFor(eventComment => eventComment.EventId)
                .NotEmpty();       
        }
    }

    public class PostCommentValidation : AbstractValidator<PostCommentRequestDto>
    {
        public PostCommentValidation()
        {
            RuleFor(postComment => postComment.PostId)
                .NotEmpty();            
        }
    }

    public class CommentLocalizationValidation : AbstractValidator<CommentLocalizationDto>
    {
        public CommentLocalizationValidation()
        {
            RuleFor(x => x.Key)
                 .NotEmpty();

            RuleFor(comment => comment.Text)
                .NotEmpty()
                .WithMessage("comment text cannot be empty.");

            RuleFor(comment => comment.Author)
                .NotEmpty()
                .WithMessage("author name cannot be empty.");
        }
    }
}
