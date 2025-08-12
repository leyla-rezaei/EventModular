using EventModular.Shared.Base.Entities;
using EventModular.Shared.Constants;
using EventModular.Shared.Enums.Discounts;

namespace EventModular.Server.Modules.Discounts.Domain.Entities;
[Table(nameof(Coupon), Schema = SchemaConsts.Discount)]
public class Coupon : BaseEntity
{
    public Guid OrganizerId { get; set; }
    public bool IsForSubdomain { get; set; }

    public CouponTargetType TargetType { get; set; }

    public string Code { get; set; } = string.Empty;

    public DiscountType DiscountType { get; set; }

    public decimal? DiscountValue { get; set; }

    public decimal? Percent { get; set; }
    public DateTimeOffset ValidFrom { get; set; }
    public DateTimeOffset ValidTo { get; set; }
    public int UsableCount { get; set; }
    public int Usage { get; set; }

    public decimal? MinInvoiceLimit { get; set; }
    public decimal? MaxInvoiceLimit { get; set; }

    public bool IsActive { get; set; }

    public ICollection<CouponLocalization> Localizations { get; set; } = new List<CouponLocalization>();

}
