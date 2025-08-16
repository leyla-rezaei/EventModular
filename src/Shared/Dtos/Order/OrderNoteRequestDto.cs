namespace EventModular.Shared.Dtos.Order;
public class OrderNoteRequestDto
{
    public Guid OrderId { get; set; }
    public Guid CreatedByUserId { get; set; }

    public List<OrderNoteLocalizationDto> Localizations { get; set; } 
}
 
public class OrderNoteLocalizationDto
{
    public string Key { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
}
