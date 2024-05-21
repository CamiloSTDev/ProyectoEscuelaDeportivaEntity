using System;
using System.Collections.Generic;

namespace Entity_Framework_Escuela_Deportiva.Models;

public partial class Grupo
{
    public int IdGrupo { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdHorario { get; set; }

    public virtual ICollection<Docente> Docentes { get; set; } = new List<Docente>();

    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();

    public virtual Horario IdHorarioNavigation { get; set; } = null!;
}
