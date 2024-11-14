using System;
using System.Collections.Generic;

namespace SyncAMS.Models;

public partial class NonProgramCompetency
{
    public int NonProgramCompetencyId { get; set; }

    public byte Domain { get; set; }

    public string CompetencyCode { get; set; } = null!;

    public byte? IsProgramSpecific { get; set; }
}
