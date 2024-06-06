namespace Entity_Framework_Escuela_Deportiva.ViewModels
{
    public class UsuarioVM
    {

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public int Doc { get; set; }

        public string Telefono { get; set; } = null!;

        public string FechaNac { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string Contraseña { get; set; } = null!;

        public string ConfirmarContraseña { get; set; } = null!;

        public int  IdGrupo { get; set; }

    }


}
