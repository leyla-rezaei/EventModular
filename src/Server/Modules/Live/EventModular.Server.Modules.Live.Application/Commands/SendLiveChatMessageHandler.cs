using EventModular.Server.Modules.Live.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Dtos.Live;
using MediatR;

namespace EventModular.Server.Modules.Live.Application.Commands;
public class SendLiveChatMessageHandler : IRequestHandler<SendLiveChatMessageCommand, LiveChatMessageResponseDto>
{
    private readonly IApplicationDbContext _ctx;
    public SendLiveChatMessageHandler(IApplicationDbContext ctx) => _ctx = ctx;

    public async Task<LiveChatMessageResponseDto> Handle(SendLiveChatMessageCommand msg, CancellationToken ct)
    {
        var r = msg.Request;
        var entity = new LiveChatMessage
        {
            LiveRoomId = r.LiveRoomId,
            SenderId = r.SenderId,
            SentAt = DateTimeOffset.UtcNow,
            IsPinned = r.Pin
        };

        await _ctx.Set<LiveChatMessage>().AddAsync(entity, ct);
        await _ctx.SaveChangesAsync(ct);

        return new LiveChatMessageResponseDto
        {
            Id = entity.Id,
            LiveRoomId = entity.LiveRoomId,
            SenderId = entity.SenderId,
            SentAt = entity.SentAt,
            IsPinned = entity.IsPinned
        };
    }
}
