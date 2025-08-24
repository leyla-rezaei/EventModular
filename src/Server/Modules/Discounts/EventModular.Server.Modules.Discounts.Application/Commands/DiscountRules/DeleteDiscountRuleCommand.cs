using EventModular.Shared.Constants.Response;
using MediatR;

namespace EventModular.Server.Modules.Discounts.Application.Commands.DiscountRules;
public record DeleteDiscountRuleCommand(Guid Id) : IRequest<JustResponse>;

