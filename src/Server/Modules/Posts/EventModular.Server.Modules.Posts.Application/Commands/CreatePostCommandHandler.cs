using EventModular.Server.Modules.Posts.Domain.Entities;
using EventModular.Shared.Dtos.Posts;
using EventModular.Shared.Abstractions.Persistence;
using MediatR;


namespace EventModular.Server.Modules.Posts.Application.Commands;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, PostResponseDto>
{
    private readonly IApplicationDbContext _context;

    public CreatePostCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PostResponseDto> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var entity = new Post
        {
            PublishStatus = request.Post.PublishStatus,
            IsSchedulingPublish = request.Post.IsSchedulingPublish,
            PublishOn = request.Post.PublishOn,
            Visibility = request.Post.Visibility,
            PostFormat = request.Post.PostFormat,
            PostType = request.Post.PostType,
            Password = request.Post.Password,
            Order = request.Post.Order,
            ParentId = request.Post.ParentId,
            IsPrivate = request.Post.IsPrivate,
            IsCommentsAllowed = request.Post.IsCommentsAllowed,
            IsAllowPinbacks = request.Post.IsAllowPinbacks,
            WriterId = request.OrganizerId,  
            Revision = request.Post.Revision,
            CommentCount = 0,
            ViewCount = 0,
            RevisionCount = 1,
            Localizations = request.Post.Localizations?.Select(x => new PostLocalization
            {
                Slug = x.Slug,
                Tags = x.Tags,
            }).ToList() ?? new List<PostLocalization>()
        };

        await  _context.Set<Post>().AddAsync(entity,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new PostResponseDto
        {
            Id = entity.Id,
            PublishStatus = entity.PublishStatus,
            IsSchedulingPublish = entity.IsSchedulingPublish,
            PublishOn = entity.PublishOn,
            Visibility = entity.Visibility,
            PostFormat = entity.PostFormat,
            PostType = entity.PostType,
            Password = entity.Password,
            Order = entity.Order,
            ParentId = entity.ParentId,
            IsPrivate = entity.IsPrivate,
            IsCommentsAllowed = entity.IsCommentsAllowed,
            IsAllowPinbacks = entity.IsAllowPinbacks,
            WriterId = entity.WriterId,
            Revision = entity.Revision,
            CommentCount = entity.CommentCount,
            ViewCount = entity.ViewCount,
            RevisionCount = entity.RevisionCount,
            Localizations = entity.Localizations.Select(x => new PostLocalizationDto
            {
                Slug = x.Slug,
                Tags = x.Tags,
               Key = x.Key,
            }).ToList()
        };
    }
}


