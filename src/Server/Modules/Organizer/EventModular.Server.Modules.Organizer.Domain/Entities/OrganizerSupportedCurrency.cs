using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Organizer.Domain.Entities;
[Table(nameof(OrganizerSupportedCurrency), Schema = SchemaConsts.Organizer)]
public class OrganizerSupportedCurrency : BaseEntity
{
    public Guid OrganizerId { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;
}
