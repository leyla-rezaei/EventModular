namespace EventModular.Shared.Dtos.Rate;
public class RateRequestDto
{
    public uint Value { get; set; }
}

public class CommentRateRequestDto : RateRequestDto
{
    public Guid CommentId { get; set; }
}

public class CourseRateRequestDto : RateRequestDto
{
    public Guid CourseId { get; set; }
}

public class EventRateRequestDto : RateRequestDto
{
    public Guid EventId { get; set; }
}

public class PostRateRequestDto : RateRequestDto
{
    public Guid PostId { get; set; }
}
