using Entity_Framework_Escuela_Deportiva.Models;

namespace Entity_Framework_Escuela_Deportiva.api
{
    public class HorarioFullCalendarDTO
    {
        public int id { get; set; }

        public string title { get; set; }

        public string start { get; set; }

        public string end { get; set; }


        public HorarioFullCalendarDTO(Horario horario)

        {

            id = horario.IdHorario;

            title = horario.IdHorario.ToString(); // Or any other title you want

            start = horario.Fecha?.ToString("yyyy-MM-dd") + "T" + horario.HoraInicio.ToString("HH:mm");

            end = horario.Fecha?.ToString("yyyy-MM-dd") + "T" + horario.HoraFin.ToString("HH:mm");

        }

    }
}
