using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Tickets.Domain.Entities;
[Table(nameof(Ticket), Schema = SchemaConsts.Ticket)]
public class Ticket : BaseEntity
{
    public Guid EventId { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public int SoldCount { get; set; }

    public ICollection<TicketLocalization> Localizations { get; set; } = new List<TicketLocalization>();
    public ICollection<TicketPrice> Prices { get; set; } = new List<TicketPrice>();
}
