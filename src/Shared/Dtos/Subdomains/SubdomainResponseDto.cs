namespace EventModular.Shared.Dtos.Subdomains;
public class SubdomainResponseDto
{
    public Guid Id { get; set; }
    public Guid OrganizerId { get; set; }
    public string DomainName { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public List<SubdomainLocalizationDto>? Localizations { get; set; }
}
