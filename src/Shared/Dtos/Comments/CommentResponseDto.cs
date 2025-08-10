using EventModular.Shared.Enums.Comments;

namespace EventModular.Shared.Dtos.Comments;
public class CommentResponseDto 
{
    public Guid Id { get; set; }
    public CommentStatus CommentStatus { get; set; }
    public string AuthorEmail { get; set; }
    public Guid? UserId { get; set; }
    public Guid? ReplyedToCommentId { get; set; }
    public CommentShortDto? ReplyedToComment { get; set; }
    public CommentType CommentType { get; set; }
    public string Content { get; set; } = string.Empty;
    public VisibilityType Visibility { get; set; }
    public List<CommentLocalizationDto>? Localizations { get; set; } = new();
}

