using System;
using System.Collections.Generic;

namespace SyncAMS.Models;

public partial class ProvinceState
{
    public int IdprovinceState { get; set; }

    public string Name { get; set; } = null!;

    public int Idcountry { get; set; }

    public virtual Country IdcountryNavigation { get; set; } = null!;
}
