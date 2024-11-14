using System;
using System.Collections.Generic;

namespace SyncAMS.Models;

public partial class VwObjectif
{
    public int Idobjectif { get; set; }

    public string Numero { get; set; } = null!;

    public string Nom { get; set; } = null!;

    public int IdtypeComposanteFormation { get; set; }

    public DateTime DateActivation { get; set; }

    public DateTime? DateDesactivation { get; set; }

    public int IdorganismeCreateur { get; set; }

    public string LangueOrigine { get; set; } = null!;

    public string? NomTraduit { get; set; }
}
