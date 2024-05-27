$.ajax({
    url: '/Horario/GetTrainingSchedules',
    type: 'GET',
    success: function (response) {
        console.log("Datos cargados correctamente");

        document.addEventListener('DOMContentLoaded', function () {
            var calendarEl = document.getElementById('calendar');
            var calendar = new FullCalendar.Calendar(calendarEl, {
                initialView: 'dayGridMonth',
                events: response.data
            });
            calendar.render();
        });
    },
    error: function (error) {
        console.log("Error al cargar los datos");
    }
});
