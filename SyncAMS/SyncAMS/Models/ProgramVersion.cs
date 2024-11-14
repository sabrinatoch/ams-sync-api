using System;
using System.Collections.Generic;

namespace SyncAMS.Models;

public partial class ProgramVersion
{
    public int IdprogramVersion { get; set; }

    public int Idprogram { get; set; }

    public int IdprogramClara { get; set; }

    public virtual Program IdprogramNavigation { get; set; } = null!;
}
