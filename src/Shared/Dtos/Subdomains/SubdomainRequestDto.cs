namespace EventModular.Shared.Dtos.Subdomains;
public class SubdomainRequestDto
{
    public Guid OrganizerId { get; set; }
    public string DomainName { get; set; } = string.Empty;
    public List<SubdomainLocalizationDto>? Localizations { get; set; }
}

public class SubdomainLocalizationDto
{
    public string Key { get; set; } = string.Empty; 
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

