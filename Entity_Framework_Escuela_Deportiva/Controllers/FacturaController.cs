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

    // Acción para que el estudiante vea la factura con el valor en 0
    [HttpGet]
    public IActionResult GetInvoiceByDocNumber(string docNumber)
    {
        var estudiante = _context.Estudiantes.FirstOrDefault(e => Convert.ToString(e.Doc) == docNumber);

        if (estudiante == null)
        {
            // Mostrar alerta de estudiante no encontrado
            TempData["ErrorMessage"] = "Estudiante no encontrado";
            return RedirectToAction("Index");
        }

        var factura = _context.Facturas
            .Include(f => f.Estudiantes)
            .FirstOrDefault(f => f.Doc == estudiante.Doc);

        if (factura == null)
        {
            // Mostrar alerta de factura no encontrada
            TempData["ErrorMessage"] = "Factura no encontrada";
            return RedirectToAction("Index");
        }

        return View("Index", factura); // Mostrar la vista Index con los detalles de la factura
    }

    // Acción para mostrar la vista UpdateInvoice (para administrador)
    public IActionResult UpdateInvoice()
    {
        var facturas = _context.Facturas.Include(f => f.Estudiantes).ToList();
        return View(facturas); // Mostrar la vista UpdateInvoice con la lista de facturas
    }

    // Acción para manejar el POST desde el formulario en UpdateInvoice.cshtml
    [HttpPost]
    public IActionResult UpdateInvoice(int facturaId)
    {
        var factura = _context.Facturas
            .Include(f => f.Estudiantes)
            .FirstOrDefault(f => f.IdFactura == facturaId);

        if (factura == null)
        {
            return NotFound("Factura no encontrada");
        }

        // Marcar la factura como pagada (valor en 0)
        factura.ValorFac = 0;
        _context.SaveChanges();

        return RedirectToAction("UpdateInvoice"); // Redirigir a la acción UpdateInvoice (GET) después de actualizar
    }

}
