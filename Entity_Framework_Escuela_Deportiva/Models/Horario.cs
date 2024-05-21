using System;
using System.Collections.Generic;

namespace Entity_Framework_Escuela_Deportiva.Models;

public partial class Horario
{
    public int IdHorario { get; set; }

    public DateOnly? Fecha { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public virtual ICollection<Grupo> Grupos { get; set; } = new List<Grupo>();
}
