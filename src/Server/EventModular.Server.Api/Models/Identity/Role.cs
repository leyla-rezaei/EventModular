﻿namespace EventModular.Server.Api.Models.Identity;

public partial class Role : IdentityRole<Guid>
{
    public List<UserRole> Users { get; set; } = [];
    public List<RoleClaim> Claims { get; set; } = [];
}

