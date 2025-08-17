using EventModular.Server.Modules.Live.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Dtos.Live;
using MediatR;

namespace EventModular.Server.Modules.Live.Application.Commands;
public class CreateLiveRoomHandler : IRequestHandler<CreateLiveRoomCommand, LiveRoomResponseDto>
{
    private readonly IApplicationDbContext _context;

    public CreateLiveRoomHandler(IApplicationDbContext context)
    {
        _context = context;
    }

        public async Task<LiveRoomResponseDto> Handle(CreateLiveRoomCommand  createLiveRoom, CancellationToken cancellationToken)
        {
            var r = createLiveRoom.dto;

            var entity = new LiveRoom
            {
                EventId = r.EventId,
                OrganizerId = r.OrganizerId,
                ThumbnailUrl = r.ThumbnailUrl,
                ScheduledStart = r.ScheduledStart,
                ScheduledEnd = r.ScheduledEnd,

                AllowAnonymous = r.AllowAnonymous,
                RequireTicket = r.RequireTicket,
                IsPrivate = r.IsPrivate,
                MaxParticipants = r.MaxParticipants,


                VideoQuality = r.VideoQuality,
                EnableAdaptiveBitrate = r.EnableAdaptiveBitrate,
                DefaultLanguage = r.DefaultLanguage,
                EnableSubtitles = r.EnableSubtitles,
                EnableSimultaneousTranslation = r.EnableSimultaneousTranslation,
                Localizations = r.Localizations.Select(x => new LiveRoomLocalization
                {
                    Key = x.Key,
                    Title = x.Title,
                    Description = x.Description
                }).ToList()
            };

            await _context.SaveChangesAsync(cancellationToken);

            return new LiveRoomResponseDto
            {
                Id = entity.Id,
                EventId = entity.EventId,
                OrganizerId = entity.OrganizerId,
                ThumbnailUrl = entity.ThumbnailUrl,
                ScheduledStart = entity.ScheduledStart,
                ScheduledEnd = entity.ScheduledEnd,
                ActualStart = entity.ActualStart,
                ActualEnd = entity.ActualEnd,
                IsActive = entity.IsActive,
                IsRecorded = entity.IsRecorded,
                RecordingUrl = entity.RecordingUrl,
                AllowReplay = entity.AllowReplay,
                AllowAnonymous = entity.AllowAnonymous,
                RequireTicket = entity.RequireTicket,
                IsPrivate = entity.IsPrivate,
                MaxParticipants = entity.MaxParticipants,
                CurrentParticipants = entity.CurrentParticipants,
                AllowChat = entity.AllowChat,
                AllowQnA = entity.AllowQnA,
                AllowPolls = entity.AllowPolls,
                AllowReactions = entity.AllowReactions,
                VideoQuality = entity.VideoQuality,
                EnableAdaptiveBitrate = entity.EnableAdaptiveBitrate,
                DefaultLanguage = entity.DefaultLanguage,
                EnableSubtitles = entity.EnableSubtitles,
                EnableSimultaneousTranslation = entity.EnableSimultaneousTranslation,
                IsPasswordProtected = entity.IsPasswordProtected,
                Localizations = entity.Localizations.Select(x => new LiveRoomLocalizationDto
                {
                    Key = x.Key,
                    Title = x.Title,
                    Description = x.Description
                }).ToList()
            };
        }
    }
