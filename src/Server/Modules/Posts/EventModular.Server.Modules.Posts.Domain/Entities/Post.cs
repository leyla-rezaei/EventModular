using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Post;

namespace EventModular.Server.Modules.Posts.Domain.Entities;
[Table(nameof(Post), Schema = nameof(SchemaConsts.Post))]
public class Post : BaseEntity
{
    public Guid SubdomainId { get; set; }
    public Guid WriterId { get; set; }
    public PublishStatus PublishStatus { get; set; }
    public bool IsSchedulingPublish { get; set; }
    public DateTimeOffset? PublishOn { get; set; }
    public Visibility Visibility { get; set; }
    public PostFormat PostFormat { get; set; }
    public PostType PostType { get; set; }
    public string Password { get; set; }
    public int? Order { get; set; }
    public Guid? ParentId { get; set; }
    public Post Parent { get; set; }
    public bool IsPrivate { get; set; }
    public bool IsCommentsAllowed { get; set; }
    public bool IsAllowPinbacks { get; set; }
    public int Revision { get; set; }
    public int CommentCount { get; set; }
    public int ViewCount { get; set; }
    public int RevisionCount { get; set; }
    public Guid? ThumbnailMediaId { get; set; }

    public ICollection<PostLocalization> Localizations { get; set; }
    
}
