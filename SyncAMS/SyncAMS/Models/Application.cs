using System;
using System.Collections.Generic;

namespace SyncAMS.Models;

public partial class Application
{
    public int Idapplication { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<ApplicationRole> ApplicationRoles { get; set; } = new List<ApplicationRole>();
}
