using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;

namespace EventModular.Server.Modules.Discounts.Domain.Entities;
[Table(nameof(Campaign), Schema = SchemaConsts.Discount)]
public class Campaign : BaseEntity
{
    public Guid? OrganizerId { get; set; }
    public bool IsForSubdomain { get; set; }
    public bool IsActive { get; set; }
    public DateTimeOffset ValidFrom { get; set; }
    public DateTimeOffset ValidTo { get; set; }

    public ICollection<CampaignLocalization> Localizations { get; set; } = new List<CampaignLocalization>();

    public ICollection<DiscountRule> Rules { get; set; } = new List<DiscountRule>();
}
