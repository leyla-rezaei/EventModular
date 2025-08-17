namespace EventModular.Shared.Dtos.Live;
public class LiveParticipantRequestDto
{
    public Guid LiveRoomId { get; set; }
    public Guid UserId { get; set; }
    public bool IsModerator { get; set; }
    public bool IsMuted { get; set; }
    public bool IsKicked { get; set; }
}
