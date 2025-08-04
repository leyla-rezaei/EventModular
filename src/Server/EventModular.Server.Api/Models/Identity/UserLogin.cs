namespace EventModular.Server.Api.Models.Identity;

public class UserLogin : IdentityUserLogin<Guid>
{
    public User? User { get; set; }
}
