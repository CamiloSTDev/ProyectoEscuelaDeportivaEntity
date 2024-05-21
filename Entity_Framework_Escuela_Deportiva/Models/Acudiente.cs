using System;
using System.Collections.Generic;

namespace Entity_Framework_Escuela_Deportiva.Models;

public partial class Acudiente
{
    public int IdAcudiente { get; set; }

    public string NombreAcu { get; set; } = null!;

    public string ApellidoAcu { get; set; } = null!;

    public long TelefonoAcu { get; set; }

    public string DireccionAcu { get; set; } = null!;

    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
}
