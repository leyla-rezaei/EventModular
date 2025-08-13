using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Tickets.Domain.Entities;
[Table(nameof(TicketLocalization), Schema = SchemaConsts.Localization)]
public class TicketLocalization : BaseLocalization
{
    public Guid TicketId { get; set; }
    public Ticket Ticket { get; set; }

    public string Title { get; set; } = string.Empty;
}

