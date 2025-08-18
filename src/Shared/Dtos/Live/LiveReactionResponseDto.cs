namespace EventModular.Shared.Dtos.Live;
public class LiveReactionResponseDto
{
    public Guid Id { get; set; }
    public Guid LiveRoomId { get; set; }
    public Guid UserId { get; set; }
    public string Emoji { get; set; } = "👍";
    public DateTimeOffset SentAt { get; set; }
}
