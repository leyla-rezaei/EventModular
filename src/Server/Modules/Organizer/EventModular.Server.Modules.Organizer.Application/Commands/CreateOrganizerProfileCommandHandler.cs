using EventModular.Server.Modules.Organizer.Application;
using EventModular.Server.Modules.Organizer.Application.Commands;
using EventModular.Server.Modules.Organizer.Domain.Entities;
using EventModular.Shared.Abstractions.Persistence;
using EventModular.Shared.Dtos.Organizer;
using MediatR;
using Microsoft.Extensions.Options;

public class CreateOrganizerProfileCommandHandler
    : IRequestHandler<CreateOrganizerProfileCommand, OrganizerProfileResponseDto>
{
    private readonly IApplicationDbContext _context;
    private readonly OrganizerSettings _settings;

    public CreateOrganizerProfileCommandHandler(
        IApplicationDbContext context,
        IOptions<OrganizerSettings> options)
    {
        _context = context;
        _settings = options.Value;
    }

    public async Task<OrganizerProfileResponseDto> Handle(CreateOrganizerProfileCommand request, CancellationToken cancellationToken)
    {
        var dto = request.dto;

        //check image size
        if (!string.IsNullOrEmpty(dto.ProfileImageUrl))
        {
            //get file size
            var fileSizeInMB = await GetFileSizeInMB(dto.ProfileImageUrl);
            if (fileSizeInMB > _settings.MaxProfilePictureSizeInMB)
                throw new ValidationException($"Profile picture exceeds max allowed size of {_settings.MaxProfilePictureSizeInMB}MB.");
        }

        var organizer = new OrganizerProfile
        {
            UserId = dto.UserId,
            ProfileImageUrl = dto.ProfileImageUrl,
            WebsiteUrl = dto.WebsiteUrl,
            Subdomain = dto.Subdomain
        };

        await _context.Set<OrganizerProfile>().AddAsync(organizer, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return new OrganizerProfileResponseDto
        {
            Id = organizer.Id,
            UserId = organizer.UserId,
            ProfileImageUrl = organizer.ProfileImageUrl,
            WebsiteUrl = organizer.WebsiteUrl,
            Subdomain = organizer.Subdomain,
            SupportedCurrencies = dto.SupportedCurrencies,
            Localizations = dto.Localizations
        };
    }

    //get file size
    private async Task<int> GetFileSizeInMB(string fileUrl)
    {
        // TODO:implement a method for file size


        return await Task.FromResult(2); 
    }
}
