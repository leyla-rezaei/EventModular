namespace EventModular.Shared.Dtos.Live;
public class LiveChatMessageRequestDto
{
    public Guid LiveRoomId { get; set; }
    public Guid SenderId { get; set; }
    public bool Pin { get; set; }

    public List<LiveChatMessageLocalizationDto>? Localizations { get; set; }
}

public class LiveChatMessageLocalizationDto
{
    public string Key { get; set; }
    public string Message { get; set; } = string.Empty;
}
