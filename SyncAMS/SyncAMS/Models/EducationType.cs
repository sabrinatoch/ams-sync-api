using System;
using System.Collections.Generic;

namespace SyncAMS.Models;

public partial class EducationType
{
    public int IdeducationType { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Program> Programs { get; set; } = new List<Program>();
}
