using System;
using System.Collections.Generic;

namespace SyncAMS.Models;

public partial class UserRole
{
    public int IduserRole { get; set; }

    public int Iduser { get; set; }

    public int Idrole { get; set; }

    public bool IsActive { get; set; }

    public virtual Role IdroleNavigation { get; set; } = null!;

    public virtual User IduserNavigation { get; set; } = null!;
}
