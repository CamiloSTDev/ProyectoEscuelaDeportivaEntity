using System;
using System.Collections.Generic;

namespace Entity_Framework_Escuela_Deportiva.Models;

public partial class Foro
{
    public string Titulo { get; set; } = null!;

    public string Contenido { get; set; } = null!;

    public int IdForo { get; set; }
}
