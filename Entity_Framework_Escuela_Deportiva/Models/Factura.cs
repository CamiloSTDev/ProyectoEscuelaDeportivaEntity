using System;
using System.Collections.Generic;

namespace Entity_Framework_Escuela_Deportiva.Models;

public partial class Factura
{
    public int IdFactura { get; set; }

    public DateOnly FechaFac { get; set; }

    public int ValorFac { get; set; }

    public int Doc { get; set; }

    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
}
