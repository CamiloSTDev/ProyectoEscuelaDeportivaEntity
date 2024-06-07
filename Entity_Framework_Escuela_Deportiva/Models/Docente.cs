using System;
using System.Collections.Generic;

namespace Entity_Framework_Escuela_Deportiva.Models;

public partial class Docente
{
    public int IdDocente { get; set; }

    public string Nombre { get; set; } = null!;

    public long Telefono { get; set; }

    public int IdGrupo { get; set; }
    public string Contraseña { get; set; } = null!;
    public virtual Grupo IdGrupoNavigation { get; set; } = null!;
}
