using System;
using System.Collections.Generic;

namespace SyncAMS.Models;

public partial class VwSelectActiveUserRole
{
    public int? Idemploye { get; set; }

    public int Iduser { get; set; }

    public bool IsActive { get; set; }
}
