namespace EventModular.Shared.Dtos.Live;
public class LiveQuestionResponseDto
{
    public Guid Id { get; set; }
    public Guid LiveRoomId { get; set; }
    public Guid UserId { get; set; }
    public bool IsAnswered { get; set; }
    public Guid? AnsweredById { get; set; }
    public DateTimeOffset AskedAt { get; set; }
    public DateTimeOffset? AnsweredAt { get; set; }

    public List<LiveQuestionLocalizationDto>? Localization { get; set; }

}
