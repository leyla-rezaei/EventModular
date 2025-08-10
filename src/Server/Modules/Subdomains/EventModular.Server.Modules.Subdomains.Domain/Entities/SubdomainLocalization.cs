using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Subdomains.Domain.Entities;
[Table(nameof(SubdomainLocalization), Schema = SchemaConsts.Localization)]
public class SubdomainLocalization : BaseLocalization
{
    public Guid SubdomainId { get; set; }
    public Subdomain? Subdomain { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
