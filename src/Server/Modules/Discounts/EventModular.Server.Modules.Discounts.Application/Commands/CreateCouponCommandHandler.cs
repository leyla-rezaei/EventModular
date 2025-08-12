using EventModular.Server.Modules.Discounts.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Dtos.Discounts;
using MediatR;

namespace EventModular.Server.Modules.Discounts.Infrastructure.Commands;
public class CreateCouponCommandHandler : IRequestHandler<CreateCouponCommand, CouponResponseDto>
{
    private readonly IApplicationDbContext _context;

    public CreateCouponCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<CouponResponseDto> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
    {
        var entity = new Coupon
        {
            Code = request.dto.Code,
            DiscountValue = request.dto.DiscountValue,
            DiscountType = request.dto.DiscountType,
            IsActive = request.dto.IsActive,
            IsForSubdomain = request.dto.IsForSubdomain,
            MaxInvoiceLimit = request.dto.MaxInvoiceLimit,
            MinInvoiceLimit = request.dto.MinInvoiceLimit,
            OrganizerId = request.dto.OrganizerId,
            TargetType = request.dto.TargetType,
            ValidFrom = request.dto.ValidFrom,
            ValidTo = request.dto.ValidTo,
            Localizations = request.dto.Localizations?.Select(x => new CouponLocalization
            {
                Key = x.Key,
                Description = x.Description
            }).ToList() ?? new List<CouponLocalization>()
        };

        await _context.Set<Coupon>().AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CouponResponseDto
        {
            Id = entity.Id,
            Code = entity.Code,
            DiscountValue = entity.DiscountValue,

            OrganizerId = entity.OrganizerId,
            ValidFrom = entity.ValidFrom,
            ValidTo = entity.ValidTo,
            IsActive = entity.IsActive,
            Localizations = entity.Localizations.Select(x => new CouponLocalizationDto
            {
                Key = x.Key,
                Description = x.Description
            }).ToList()
        };
    }
}
