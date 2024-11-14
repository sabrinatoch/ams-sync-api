using System;
using System.Collections.Generic;

namespace SyncAMS.Models;

public partial class Program
{
    public int Idprogram { get; set; }

    public string Name { get; set; } = null!;

    public int IdeducationType { get; set; }

    public bool IsActive { get; set; }

    public virtual EducationType IdeducationTypeNavigation { get; set; } = null!;

    public virtual ICollection<ProgramVersion> ProgramVersions { get; set; } = new List<ProgramVersion>();
}
