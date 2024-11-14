using System;
using System.Collections.Generic;

namespace SyncAMS.Models;

public partial class Country
{
    public int Idcountry { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ProvinceState> ProvinceStates { get; set; } = new List<ProvinceState>();
}
