namespace EventModular.Shared.Dtos.Order;
public class OrderHistoryResponseDto
{
    public Guid Id { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
    public Guid ChangedByUserId { get; set; }
    public DateTime ChangedAt { get; set; }
}
