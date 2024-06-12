
using Entity_Framework_Escuela_Deportiva.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


namespace Entity_Framework_Escuela_Deportiva.Controllers
{
    public class HorarioController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }


}
