let request_calendar;

$.ajax({
    url: '/Horario/GetTrainingSchedules',
    type: 'GET',
    success: function (response) {
         request_calendar = response;
        console.log("Datos cargados correctamente",request_calendar);

    },
    error: function (error) {
        console.log("Error al cargar los datos");
    }
});
document.addEventListener('DOMContentLoaded', function () {
    
    var calendarEl = document.getElementById('calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',

        events: function (info, successCallback, failureCallback) {
            
            fetch(request_calendar)
                .then(function (response) {
                    return response.json()
                })
                .then(function (data) {
                    let events = data.events.map(function (Horario) {
                        return {
                            title: Horario.Grupos,
                            start: new Date(Horario.Fecha),
                            timeStart: Horario.HoraInicio,
                            timeEnd: Horario.HoraFin
                        }
                    })
                    successCallback(events)
                })
                .catch(function (error) {
                    failureCallback(error)
                })
        }
    });
    calendar.render();
});


