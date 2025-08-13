namespace EventModular.Shared.Dtos.Tickets;
public class TicketResponseDto
{
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public int SoldCount { get; set; }
    public List<TicketLocalizationDto>? Localizations { get; set; } = new();
    public List<TicketPriceDto>? Prices { get; set; } = new();
}
