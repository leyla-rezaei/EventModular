using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Event;

namespace EventModular.Server.Modules.Events.Domain.Entities;

[Table(nameof(Event), Schema = SchemaConsts.Event)]
public class Event : BaseEntity
{
    public bool IsOnline { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Guid OrganizerId { get; set; }
    public string Location { get; set; } = string.Empty;
    public EventStatus EventStatus { get; set; }
    public string DefaultLanguage { get; set; } = string.Empty;
    public string DefaultCurrency { get; set; } = string.Empty;

    public ICollection<EventLocalization> Localizations { get; set; } = new List<EventLocalization>();
}
