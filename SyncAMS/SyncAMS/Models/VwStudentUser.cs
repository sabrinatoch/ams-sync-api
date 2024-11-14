using System;
using System.Collections.Generic;

namespace SyncAMS.Models;

public partial class VwStudentUser
{
    public int Iduser { get; set; }

    public int? Idetudiant { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string Username { get; set; } = null!;
}
