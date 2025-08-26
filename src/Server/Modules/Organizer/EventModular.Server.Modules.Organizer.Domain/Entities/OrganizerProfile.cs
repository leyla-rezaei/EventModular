using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Organizer.Domain.Entities;
[Table(nameof(OrganizerProfile), Schema = SchemaConsts.Organizer)]
public class OrganizerProfile : BaseEntity
{
    public Guid UserId { get; set; }
    public string? ProfileImageUrl { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? Subdomain { get; set; }
    public ICollection<OrganizerProfileLocalization> Localizations { get; set; } = new List<OrganizerProfileLocalization>();
    public ICollection<OrganizerSupportedCurrency>  SupportedCurrencies { get; set; } = new List<OrganizerSupportedCurrency>();

} 
