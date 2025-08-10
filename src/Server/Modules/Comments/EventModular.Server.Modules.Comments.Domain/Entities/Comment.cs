using EventModular.Shared.Base.Entities;
using EventModular.Shared.Enums.Comments;

namespace EventModular.Server.Modules.Comments.Domain.Entities;
public abstract class Comment : BaseEntity
{
    public CommentStatus CommentStatus { get; set; }
    public string AuthorEmail { get; set; }
    public Guid? UserId { get; set; }
    public int IsCommentUsefullCount { get; set; }
    public int IsCommentNotUsefullCount { get; set; }
    public Guid? ReplyedToCommentId { get; set; }
    public Comment? ReplyedToComment { get; set; }
    public CommentType CommentType { get; set; } 
    public string Content { get; set; } = string.Empty;
    public VisibilityType Visibility { get; set; } 

    #region Navigation Properties
    public ICollection<Comment> Comments { get; set; }
    public ICollection<CommentLocalization> Localizations { get; set; }
    #endregion
    public ICollection<Comment> Replies { get; set; } = new List<Comment>();
}
