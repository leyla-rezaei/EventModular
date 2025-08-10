using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Subdomains.Domain.Entities;

[Table(nameof(Subdomain), Schema = SchemaConsts.Subdomain)]
public class Subdomain : BaseEntity
{
    public Guid OrganizerId { get; set; }
    public string DomainName { get; set; } = string.Empty;
    public bool IsActive { get; set; }

    public ICollection<SubdomainLocalization> Localizations { get; set; } = new List<SubdomainLocalization>();

}
