namespace EventModular.Shared.Dtos.Live;
public class LiveQuestionRequestDto
{
    public Guid LiveRoomId { get; set; }
    public Guid UserId { get; set; }
    public string Question { get; set; } = string.Empty;
    public List<LiveQuestionLocalizationDto>? Localization { get; set; }
}


public class LiveQuestionLocalizationDto
{
    public string key { get; set; }
    public string Question { get; set; } = string.Empty;
    public string? Answer { get; set; }
}
