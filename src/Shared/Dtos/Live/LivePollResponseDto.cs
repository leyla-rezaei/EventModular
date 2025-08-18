namespace EventModular.Shared.Dtos.Live;
public class LivePollResponseDto
{
    public Guid Id { get; set; }
    public Guid LiveRoomId { get; set; }
    public string Question { get; set; } = string.Empty;
    public bool IsAnonymous { get; set; }
    public bool IsMultipleChoice { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? ExpiresAt { get; set; }
    public bool IsClosed { get; set; }
    public List<LivePollLocalizationDto> Localizations { get; set; } = new();
    public List<LivePollOptionResponseDto> Options { get; set; } = new();
}
public class LivePollOptionResponseDto
{
    public Guid Id { get; set; }
    public string OptionText { get; set; } = string.Empty;
    public int VoteCount { get; set; }
    public List<LivePollOptionLocalizationDto> Localizations { get; set; } = new();
}
