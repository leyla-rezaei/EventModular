using EventModular.Shared.Dtos.Posts;
using MediatR;

namespace EventModular.Server.Modules.Posts.Application.Commands;

public record CreatePostCommand(PostRequestDto Post, Guid OrganizerId) : IRequest<PostResponseDto>;

