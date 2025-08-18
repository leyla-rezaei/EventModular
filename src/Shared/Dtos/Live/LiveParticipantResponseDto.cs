namespace EventModular.Shared.Dtos.Live;
public class LiveParticipantResponseDto
{
    public Guid Id { get; set; }
    public Guid LiveRoomId { get; set; }
    public Guid UserId { get; set; }
    public bool IsModerator { get; set; }
    public bool IsMuted { get; set; }
    public bool IsKicked { get; set; }
    public DateTimeOffset JoinedAt { get; set; }
    public DateTimeOffset? LeftAt { get; set; }
}
