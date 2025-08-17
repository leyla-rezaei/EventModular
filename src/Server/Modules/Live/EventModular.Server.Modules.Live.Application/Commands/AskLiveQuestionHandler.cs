using EventModular.Server.Modules.Live.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Dtos.Live;
using MediatR;

namespace EventModular.Server.Modules.Live.Application.Commands;
public class AskLiveQuestionHandler : IRequestHandler<AskLiveQuestionCommand, LiveQuestionResponseDto>
{
    private readonly IApplicationDbContext _context;
    public AskLiveQuestionHandler(IApplicationDbContext context) => _context = context;

    public async Task<LiveQuestionResponseDto> Handle(AskLiveQuestionCommand  askLive, CancellationToken cancellationToken)
    {
        var r = askLive.dto;
        var entity = new LiveQuestion 
        {
            LiveRoomId = r.LiveRoomId,
            UserId = r.UserId,
            AskedAt = DateTimeOffset.UtcNow,
            IsAnswered = false
        };

        await _context.Set<LiveQuestion>().AddAsync(entity,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new LiveQuestionResponseDto
        {
            Id = entity.Id,
            LiveRoomId = entity.LiveRoomId,
            UserId = entity.UserId,
            AskedAt = entity.AskedAt,
            IsAnswered = entity.IsAnswered
        };
    }
}

