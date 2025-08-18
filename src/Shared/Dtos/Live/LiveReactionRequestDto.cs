namespace EventModular.Shared.Dtos.Live;
public class LiveReactionRequestDto
{
    public Guid LiveRoomId { get; set; }
    public Guid UserId { get; set; }
    public string Emoji { get; set; } = "👍";
}
