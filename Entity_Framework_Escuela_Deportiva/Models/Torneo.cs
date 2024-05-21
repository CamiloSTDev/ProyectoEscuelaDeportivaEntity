using System;
using System.Collections.Generic;

namespace Entity_Framework_Escuela_Deportiva.Models;

public partial class Torneo
{
    public int IdTorneo { get; set; }

    public string NombreTor { get; set; } = null!;

    public string LugarTor { get; set; } = null!;

    public DateOnly FechaTor { get; set; }

    public string DireccionTor { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public virtual ICollection<Escuela> Escuelas { get; set; } = new List<Escuela>();
}
