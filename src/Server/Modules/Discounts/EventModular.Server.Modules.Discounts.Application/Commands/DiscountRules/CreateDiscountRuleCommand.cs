using EventModular.Shared.Constants.Response;
using EventModular.Shared.Dtos.Discounts;
using MediatR;

namespace EventModular.Server.Modules.Discounts.Application.Commands.DiscountRules;
public record CreateDiscountRuleCommand(DiscountRuleDto dto) : IRequest<SingleResponse<DiscountRuleDto>>;
