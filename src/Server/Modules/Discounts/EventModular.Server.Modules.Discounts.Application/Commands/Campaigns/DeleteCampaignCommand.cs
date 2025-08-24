using EventModular.Shared.Constants.Response;
using MediatR;

namespace EventModular.Server.Modules.Discounts.Application.Commands.Campaigns;
public record DeleteCampaignCommand(Guid Id) : IRequest<JustResponse>;

