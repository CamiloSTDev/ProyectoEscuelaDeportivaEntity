using System;
using System.Collections.Generic;

namespace Entity_Framework_Escuela_Deportiva.Models;

public partial class Estudiante
{ 
    public int IdUsuario { get; set; } 

    public int Doc { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string FechaNac { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public int? AsisTotal { get; set; }

    public int IdGrupo { get; set; }

    public int IdFactura { get; set; }

    public int IdAcudiente { get; set; }

    public virtual ICollection<Foro> Foros { get; set; } = new List<Foro>();

    public virtual Acudiente IdAcudienteNavigation { get; set; } = null!;

    public virtual Factura IdFacturaNavigation { get; set; } = null!;

    public virtual Grupo IdGrupoNavigation { get; set; } = null!;
}
