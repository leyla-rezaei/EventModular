namespace EventModular.Shared.Dtos.Tickets;
public class TicketRequestDto
{
    public Guid EventId { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public int SoldCount { get; set; }
    public List<TicketLocalizationDto>? Localizations { get; set; }
    public List<TicketPriceDto>? Prices { get; set; }
}

public class TicketLocalizationDto
{
    public string Key { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
}


public class TicketPriceDto
{
    public Guid Id { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
