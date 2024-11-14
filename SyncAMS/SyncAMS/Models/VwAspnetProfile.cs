using System;
using System.Collections.Generic;

namespace SyncAMS.Models;

public partial class VwAspnetProfile
{
    public Guid UserId { get; set; }

    public string PropertyNames { get; set; } = null!;

    public string PropertyValuesString { get; set; } = null!;

    public byte[] PropertyValuesBinary { get; set; } = null!;

    public DateTime LastUpdatedDate { get; set; }
}
