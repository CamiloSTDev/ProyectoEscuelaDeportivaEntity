using Microsoft.AspNetCore.Mvc;
using Entity_Framework_Escuela_Deportiva.Data;
using Entity_Framework_Escuela_Deportiva.Models;
using Entity_Framework_Escuela_Deportiva.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;

namespace Entity_Framework_Escuela_Deportiva.Controllers
{
    [Authorize] // Asegúrate de que solo los usuarios autenticados puedan acceder
    public class ProfileController : Controller
    {
        private readonly EscuelaDeportivaContext _context;

        public ProfileController()
        {
            _context = new EscuelaDeportivaContext();
        }

        // GET: Account/Profile
        public  ActionResult Profile(string pNombres, int pDoc)
        {
            List<Estudiante> Lista = [];
            string connectionString = "EcuelaDeportiva"; // Se define la cadena de conexión

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT IdUsuario, Doc, Nombres, Apellidos, Telefono, Fecha_nac, Correo, Contraseña, AsisTotal, IdGrupo " +
                               "FROM Estudiante " +
                               "WHERE Nombres LIKE @pNombres AND Doc LIKE @pDoc";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pNombres", "%" + pNombres + "%");
                cmd.Parameters.AddWithValue("@pDoc", "%" + pDoc + "%");

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Estudiante estudiante = new Estudiante
                    {
                        IdUsuario = reader.GetInt32(0),
                        Doc = reader.GetInt32(1),
                        Nombres = reader.GetString(2),
                        Apellidos = reader.GetString(3),
                        Telefono = reader.GetString(4),
                        FechaNac = reader.GetString(5),
                        Correo = reader.GetString(6),
                        Contraseña = reader.GetString(7),
                        AsisTotal = reader.GetInt32(8),
                        IdGrupo = reader.GetInt32(9)
                    };

                    Lista.Add(estudiante);
                }

                conn.Close();
            }

            return View(Lista); // Devuelve la lista de personas a una vista
        }
    }
}
