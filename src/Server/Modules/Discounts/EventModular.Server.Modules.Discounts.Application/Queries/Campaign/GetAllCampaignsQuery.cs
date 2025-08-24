using EventModular.Shared.Constants.Response;
using EventModular.Shared.Dtos.Discounts;
using MediatR;

namespace EventModular.Server.Modules.Discounts.Application.Queries.Campaign;
public record GetAllCampaignsQuery() : IRequest<ListResponse<CampaignResponseDto>>;

