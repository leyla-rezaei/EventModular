using EventModular.Shared.Dtos.Comments;
using MediatR;

namespace EventModular.Server.Modules.Comments.Application.Commands;
public record CreateCommentCommand(CommentRequestDto dto, Guid CurrentUserId) : IRequest<CommentResponseDto>;
