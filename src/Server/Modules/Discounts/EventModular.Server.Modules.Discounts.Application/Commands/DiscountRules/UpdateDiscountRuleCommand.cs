using EventModular.Shared.Constants.Response;
using EventModular.Shared.Dtos.Discounts;
using MediatR;

namespace EventModular.Server.Modules.Discounts.Application.Commands.DiscountRules;
public record UpdateDiscountRuleCommand(Guid Id, DiscountRuleDto dto) : IRequest<SingleResponse<DiscountRuleDto>>;

