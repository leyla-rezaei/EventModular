namespace EventModular.Shared.Dtos.Live;
public class LivePollRequestDto
{
    public Guid LiveRoomId { get; set; }
    public string Question { get; set; } = string.Empty;

    public bool IsAnonymous { get; set; }
    public bool IsMultipleChoice { get; set; }
    public DateTimeOffset? ExpiresAt { get; set; }

    public List<LivePollOptionRequestDto> Options { get; set; } = new();
    public List<LivePollLocalizationDto> Localizations { get; set; } = new();
}

public class LivePollOptionRequestDto
{
    public string OptionText { get; set; } = string.Empty;
    public List<LivePollOptionLocalizationDto> Localizations { get; set; } = new();
}

public class LivePollLocalizationDto
{
    public string Key { get; set; } = "fa";
    public string Question { get; set; } = string.Empty;
}

public class LivePollOptionLocalizationDto
{
    public string Key { get; set; } = "fa";
    public string OptionText { get; set; } = string.Empty;
}




