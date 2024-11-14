using System;
using System.Collections.Generic;

namespace SyncAMS.Models;

public partial class Role
{
    public int Idrole { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<ApplicationRole> ApplicationRoles { get; set; } = new List<ApplicationRole>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
