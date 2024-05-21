using System;
using System.Collections.Generic;

namespace Entity_Framework_Escuela_Deportiva.Models;

public partial class Foro
{
    public int IdForo { get; set; }

    public int IdPublicacion { get; set; }

    public int IdEscuela { get; set; }

    public int IdEstudiante { get; set; }

    public int IdDocente { get; set; }

    public virtual Docente IdDocenteNavigation { get; set; } = null!;

    public virtual Escuela IdEscuelaNavigation { get; set; } = null!;

    public virtual Estudiante IdEstudianteNavigation { get; set; } = null!;
}
