using System;
using System.Collections.Generic;

namespace SyncAMS.Models;

public partial class Setting
{
    public short CurrentYearSemester { get; set; }

    public DateOnly SemesterEndDate { get; set; }
}
