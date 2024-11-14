using System;
using System.Collections.Generic;

namespace SyncAMS.Models;

public partial class Language
{
    public int LanguageId { get; set; }

    public string? Language1 { get; set; }

    public bool? IsDefault { get; set; }
}
