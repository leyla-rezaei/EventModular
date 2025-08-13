using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Tickets.Domain.Entities;
[Table(nameof(TicketPrice), Schema = SchemaConsts.Ticket)]
public class TicketPrice : BaseEntity
{
    public Guid TicketId { get; set; }
    public Ticket Ticket { get; set; }

    public string CurrencyCode { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
