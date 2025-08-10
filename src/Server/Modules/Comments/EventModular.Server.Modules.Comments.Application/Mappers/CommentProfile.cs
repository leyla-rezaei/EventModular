using AutoMapper;
using EventModular.Server.Modules.Comments.Domain.Entities;
using EventModular.Shared.Dtos.Comments;

namespace EventModular.Server.Modules.Comments.Application.Mappers;
public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<Comment, CommentResponseDto>()
            .ForMember(dest => dest.ReplyedToComment, opt => opt.MapFrom(src =>
                src.ReplyedToComment == null ? null : new CommentShortDto
                {
                    Id = src.ReplyedToComment.Id,
                    ContentPreview = src.ReplyedToComment.Content.Length > 50
                        ? src.ReplyedToComment.Content.Substring(0, 50) + "..."
                        : src.ReplyedToComment.Content
                }));
    }
}
