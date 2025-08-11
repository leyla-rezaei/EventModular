using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.AffiliateMarketing.Domain.Entities;

[Table(nameof(Affiliate), Schema = SchemaConsts.Affiliate)]
public class Affiliate : BaseEntity
{
    public Guid OrganizerId { get; set; }
    public string Code { get; set; } = string.Empty;
    public decimal CommissionRate { get; set; } 
    public bool IsActive { get; set; }

    public ICollection<AffiliateLocalization> Localizations { get; set; } = new List<AffiliateLocalization>();
}
