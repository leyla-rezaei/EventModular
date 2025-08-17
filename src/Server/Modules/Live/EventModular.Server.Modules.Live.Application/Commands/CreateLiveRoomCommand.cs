using EventModular.Shared.Dtos.Live;
using MediatR;

namespace EventModular.Server.Modules.Live.Application.Commands;
public record CreateLiveRoomCommand(LiveRoomRequestDto dto) : IRequest<LiveRoomResponseDto>;
