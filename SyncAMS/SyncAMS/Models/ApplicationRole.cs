using System;
using System.Collections.Generic;

namespace SyncAMS.Models;

public partial class ApplicationRole
{
    public int IdapplicationRole { get; set; }

    public int Idapplication { get; set; }

    public int Idrole { get; set; }

    public bool? IsActive { get; set; }

    public virtual Application IdapplicationNavigation { get; set; } = null!;

    public virtual Role IdroleNavigation { get; set; } = null!;
}
