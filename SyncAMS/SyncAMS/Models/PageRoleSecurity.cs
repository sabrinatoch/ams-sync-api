using System;
using System.Collections.Generic;

namespace SyncAMS.Models;

public partial class PageRoleSecurity
{
    public int Idapplication { get; set; }

    public string Role { get; set; } = null!;

    public string PageName { get; set; } = null!;

    public virtual Application IdapplicationNavigation { get; set; } = null!;
}
