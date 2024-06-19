namespace Entity_Framework_Escuela_Deportiva.ViewModels
{
    public class FacturaDetailViewModel
    {
        public int IdFactura { get; set; }
        public DateOnly FechaFac { get; set; }
        public int ValorFac { get; set; }
        public List<EstudianteDetailViewModel> Estudiantes { get; set; }
    }
}
