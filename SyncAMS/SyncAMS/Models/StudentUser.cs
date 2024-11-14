using System;
using System.Collections.Generic;

namespace SyncAMS.Models;

public partial class StudentUser
{
    public int Iduser { get; set; }

    public int? Idetudiant { get; set; }

    public bool IsManuallyAdded { get; set; }

    public virtual User IduserNavigation { get; set; } = null!;
}
