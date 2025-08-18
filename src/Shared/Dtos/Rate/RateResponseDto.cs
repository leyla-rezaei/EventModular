namespace EventModular.Shared.Dtos.Rate;
public class RateResponseDto
{
    public Guid Id { get; set; }
    public uint Value { get; set; }
}

public class CommentRateResponseDto : RateResponseDto
{
    public Guid Id { get; set; }
    public Guid CommentId { get; set; }
}

public class CourseRateResponseDto : RateResponseDto
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
}

public class EventRateResponseDto : RateResponseDto
{
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
}

public class PostRateResponseDto : RateResponseDto
{
    public Guid Id { get; set; }
    public Guid PostId { get; set; }
}
