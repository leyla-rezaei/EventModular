using EventModular.Shared.Enums.Discounts;

namespace EventModular.Shared.Dtos.Discounts;
public class CouponRequestDto
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
    public List<CouponLocalizationDto>? Localizations { get; set; }
}
public class CouponLocalizationDto
{
    public string Key { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
