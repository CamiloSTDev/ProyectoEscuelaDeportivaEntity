using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity_Framework_Escuela_Deportiva.Models;

public partial class Foro
{
    
    public int IdForo { get; set; }
    public string Titulo { get; set; }
    public string Contenido { get; set; }
    public int IdEscuela { get; set; } = 123456;

    public int IdEstudiante { get; set; }

    public virtual Escuela IdEscuelaNavigation { get; set; } = null!;

    public virtual Estudiante IdEstudianteNavigation { get; set; } = null!;
}
