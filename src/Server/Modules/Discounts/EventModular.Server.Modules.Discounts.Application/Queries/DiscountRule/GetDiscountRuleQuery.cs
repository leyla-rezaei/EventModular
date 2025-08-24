using EventModular.Shared.Constants.Response;
using EventModular.Shared.Dtos.Discounts;
using MediatR;

namespace EventModular.Server.Modules.Discounts.Application.Queries.DiscountRule;
public record GetDiscountRuleQuery(Guid Id) : IRequest<SingleResponse<DiscountRuleDto>>;
