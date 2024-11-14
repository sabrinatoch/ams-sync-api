using System;
using System.Collections.Generic;

namespace SyncAMS.Models;

public partial class EmployeeUser
{
    public int Iduser { get; set; }

    public int? Idemploye { get; set; }

    public bool IsNonTeaching { get; set; }

    public bool IsCoordinator { get; set; }

    public bool IsManuallyAdded { get; set; }

    public string? Department { get; set; }

    public virtual User IduserNavigation { get; set; } = null!;
}
