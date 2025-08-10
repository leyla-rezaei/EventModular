using EventModular.Shared.Enums.Comments;

namespace EventModular.Shared.Dtos.Comments;
public class CommentRequestDto 
{
    public CommentStatus CommentStatus { get; set; }
    public Guid? UserId { get; set; }
    public Guid? ReplyedToCommentId { get; set; }
    public CommentShortDto? ReplyedToComment { get; set; } 
    public CommentType CommentType { get; set; }
    public VisibilityType Visibility { get; set; }

    public List<CommentLocalizationDto>? Localizations { get; set; }
}

public class CommentLocalizationDto
{
    public string Key { get; set; }
    public string Text { get; set; }
    public string Author { get; set; }
}

public class CourseCommentRequestDto : CommentRequestDto
{ 
    public Guid CourseId { get; set; } 
}

public class PostCommentRequestDto : CommentRequestDto
{
    public Guid PostId { get; set; }
}

public class EventCommentRequestDto : CommentRequestDto 
{
    public Guid EventId { get; set; } 
}
