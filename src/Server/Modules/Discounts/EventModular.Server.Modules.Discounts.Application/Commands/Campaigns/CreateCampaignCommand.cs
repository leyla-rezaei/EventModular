using EventModular.Shared.Constants.Response;
using EventModular.Shared.Dtos.Discounts;
using MediatR;

namespace EventModular.Server.Modules.Discounts.Application.Commands.Campaigns;
public record CreateCampaignCommand(CampaignRequestDto dto) : IRequest<SingleResponse<CampaignResponseDto>>;

