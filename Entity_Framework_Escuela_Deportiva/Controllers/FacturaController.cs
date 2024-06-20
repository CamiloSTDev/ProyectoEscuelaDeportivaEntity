using Entity_Framework_Escuela_Deportiva.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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

    private int CalcularValorFactura(string docNumber)
    {
        var estudiante = _context.Estudiantes.FirstOrDefault(e => Convert.ToString(e.Doc) == docNumber);

        if (estudiante == null)
        {
            throw new Exception("Estudiante no encontrado");
        }

        var grupo = _context.Grupos
            .Include(g => g.Estudiantes)
            .FirstOrDefault(g => g.IdGrupo == estudiante.IdGrupo);

        if (grupo == null)
        {
            throw new Exception("Grupo no encontrado");
        }

        return grupo.IdGrupo switch
        {
            1 => 45,
            2 => 50,
            3 => 55,
            4 => 60,
            _ => throw new Exception("IdGrupo no válido")
        };
    }

    public IActionResult GetInvoiceByDocNumber(string docNumber)
    {
        var estudiante = _context.Estudiantes.FirstOrDefault(e => Convert.ToString(e.Doc) == docNumber);

        if (estudiante == null)
        {
            return NotFound();
        }

        var factura = _context.Facturas
            .Include(f => f.Estudiantes)
            .FirstOrDefault(f => f.Doc == estudiante.Doc);

        if (factura == null)
        {
            return NotFound();
        }

        factura.ValorFac = CalcularValorFactura(docNumber);

        return View("Index", factura);
    }
}
