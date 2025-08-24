using EventModular.Shared.Constants.Response;
using EventModular.Shared.Dtos.Discounts;
using MediatR;

namespace EventModular.Server.Modules.Discounts.Application.Queries.DiscountRule;
public record GetDiscountRulesByCampaignQuery(Guid CampaignId) : IRequest<ListResponse<DiscountRuleDto>>;

