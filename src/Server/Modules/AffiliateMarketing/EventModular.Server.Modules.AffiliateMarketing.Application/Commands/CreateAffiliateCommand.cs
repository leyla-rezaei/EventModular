using EventModular.Shared.Dtos.Affiliate;
using MediatR;

namespace EventModular.Server.Modules.AffiliateMarketing.Application.Commands;
public record CreateAffiliateCommand(AffiliateRequestDto dto) : IRequest<AffiliateResponseDto>;
