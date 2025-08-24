using EventModular.Shared.Constants.Response;
using MediatR;

namespace EventModular.Server.Modules.Discounts.Application.Commands.Coupons;
public record DeleteCouponCommand(Guid Id) : IRequest<JustResponse>;
