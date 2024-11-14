using System;
using System.Collections.Generic;

namespace SyncAMS.Models;

public partial class Province
{
    public int Idprovince { get; set; }

    public string Text { get; set; } = null!;

    public string Abbreviation { get; set; } = null!;
}
