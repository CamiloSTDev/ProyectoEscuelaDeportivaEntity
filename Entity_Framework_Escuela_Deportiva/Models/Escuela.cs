using System;
using System.Collections.Generic;

namespace Entity_Framework_Escuela_Deportiva.Models;

public partial class Escuela
{
    public int IdEscuela { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Horario { get; set; }

    public string Dirección { get; set; } = null!;

    public long Telefono { get; set; }

    public int IdTorneo { get; set; }

    public virtual ICollection<Foro> Foros { get; set; } = new List<Foro>();

    public virtual Torneo IdTorneoNavigation { get; set; } = null!;
}
