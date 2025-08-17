using EventModular.Server.Modules.Subdomains.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Dtos.Subdomains;
using EventModular.Shared.Enums.Subdomain;
using EventModular.Shared.Extensions;
using MediatR;

namespace EventModular.Server.Modules.Subdomains.Application.Commands;

public class CreateSubdomainCommandHandler : IRequestHandler<CreateSubdomainCommand, SubdomainResponseDto>
{
    private readonly IApplicationDbContext _context;

    public CreateSubdomainCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<SubdomainResponseDto> Handle(CreateSubdomainCommand request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var expiredAt = now.AddDuration(request.dto.SubscriptionDuration);

        var entity = new Subdomain
        {
            OrganizerId = request.dto.OrganizerId,
            DomainName = request.dto.DomainName,
            Status = SubdomainStatus.PendingPayment,
            Localizations = request.dto.Localizations?.Select(x => new SubdomainLocalization
            {
                Key = x.Key,
                Title = x.Title,
                Description = x.Description
            }).ToList() ?? new List<SubdomainLocalization>()
        };

        await _context.Set<Subdomain>().AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        // شبیه‌سازی ثبت پرداخت اولیه 
        var fakePaymentId = Guid.NewGuid();

        // فعال‌سازی ساب‌دامین با محاسبه تاریخ انقضا بر اساس Duration
        entity.Activate(fakePaymentId, request.dto.SubscriptionDuration);

        // افزودن رکورد در SubscriptionHistory
        entity.SubscriptionHistories.Add(new SubdomainSubscriptionHistory
        {
            Id = Guid.NewGuid(),
            SubdomainId = entity.Id,
            PaymentId = fakePaymentId,
            Duration = request.dto.SubscriptionDuration,
            ActivatedAt = entity.ActivatedAt!.Value,
            ExpiredAt = entity.ExpiredAt!.Value
        });

        await _context.SaveChangesAsync(cancellationToken);

        return new SubdomainResponseDto
        {
            Id = entity.Id,
            OrganizerId = entity.OrganizerId,
            DomainName = entity.DomainName,
            Status = entity.Status,
            ActivatedAt = entity.ActivatedAt,
            ExpiredAt = entity.ExpiredAt,
            Localizations = entity.Localizations.Select(x => new SubdomainLocalizationDto
            {
                Key = x.Key,
                Title = x.Title,
                Description = x.Description
            }).ToList(),
            SubscriptionHistories = entity.SubscriptionHistories.Select(x => new SubdomainSubscriptionHistoryDto
            {
                PaymentId = x.PaymentId,
                Duration = x.Duration,
                ActivatedAt = x.ActivatedAt,
                ExpiredAt = x.ExpiredAt
            }).ToList()
        };
    }
}
