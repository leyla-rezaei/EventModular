namespace EventModular.Shared.Dtos.Live;
public class LiveChatMessageResponseDto
{
    public Guid Id { get; set; }
    public Guid LiveRoomId { get; set; }
    public Guid SenderId { get; set; }
    public bool Pin { get; set; }
    public DateTimeOffset SentAt { get; set; }
    public bool IsPinned { get; set; }
    public List<LiveChatMessageLocalizationDto>? Localizations { get; set; }
   
}
