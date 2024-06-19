using Entity_Framework_Escuela_Deportiva.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class FacturaController : Controller
{
    private readonly EscuelaDeportivaContext _context;

    public FacturaController(EscuelaDeportivaContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    private int CalcularValorFactura( FacturaController @this,string docNumber, Estudiante? estudiante)
    {
        var estudiante2 = _context.Estudiantes.FirstOrDefault(e => Convert.ToString(e.Doc) == docNumber);

            // Use the IdFactura from the Estudiante object to query the Factura table
            var grupo = _context.Grupos
                .Include(f => f.Estudiantes)
                .FirstOrDefault(f => f.IdGrupo == estudiante2.IdGrupo);
            switch (estudiante2.IdGrupo)
            {
                case 1:
                    return 45;
                case 2:
                    return 50;
                case 3:
                    return 55;
                case 4:

                    return 60;
                default:

                    throw new Exception("IdGrupo no válido");
            }

    }

        public  IActionResult GetInvoiceByDocNumber(FacturaController @this, string docNumber, Estudiante? estudiante)
        {
            // Query the Estudiante table based on the docNumber
            estudiante = @this._context.Estudiantes.FirstOrDefault(e => Convert.ToString(e.Doc) == docNumber);

            if (estudiante != null)
            {
                // Use the IdFactura from the Estudiante object to query the Factura table
                var invoice = @this._context.Facturas
                    .Include(f => f.Estudiantes)
                    .FirstOrDefault(f => f.IdFactura == estudiante.IdFactura);

                if (invoice != null)
                {
                    return @this.View("Index", invoice);
                }
                else
                {
                    return @this.NotFound();
                }
            }
            else
            {
                return @this.NotFound();
            }
        }
}