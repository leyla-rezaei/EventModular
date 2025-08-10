using AutoMapper;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Dtos.Comments;
using MediatR;
using EventModular.Server.Modules.Comments.Domain.Entities;

namespace EventModular.Server.Modules.Comments.Application.Commands;
public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CommentResponseDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper; 

    public CreateCommentCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CommentResponseDto> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        // TODO: نیاز به بررسی مجوز نوشتن کامنت
      
        var entity = _mapper.Map<Comment>(request.dto);
        entity.UserId = request.CurrentUserId;
        await _context.Set<Comment>().AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        var responseDto = _mapper.Map<CommentResponseDto>(entity);
        return responseDto;
    }
}
