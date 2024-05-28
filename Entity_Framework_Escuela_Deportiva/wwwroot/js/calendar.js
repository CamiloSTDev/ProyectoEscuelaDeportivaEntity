

$.ajax({
    url: '/Horario/GetTrainingSchedules',
    type: 'GET'
});

//document.addEventListener('DOMContentLoaded', function () {
//    var calendarEl = document.getElementById('calendar');
//    var calendar = new FullCalendar.Calendar(calendarEl, {
//        initialView: 'dayGridMonth',
//        events: function (fetchInfo, successCallback, failureCallback) {
//            fetch('/horarios.json')
//                .then(response => response.json())
//                .then(data => {
//                    let events = data.events.map(event => {
//                        return {
//                            title: event.Grupos, // o cualquier otro campo que desees mostrar como título
//                            start: new Date(event.Fecha + 'T' + event.HoraInicio),
//                            end: new Date(event.Fecha + 'T' + event.HoraFin)
//                        };
//                    });
//                    successCallback(events);
//                })
//                .catch(error => failureCallback(error));
//        }
//    });
//    calendar.render();
//});

document.addEventListener('DOMContentLoaded', function () {
    let request_calendar = "/horarios.json";
    var calendarEl = document.getElementById('calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        events: function (info, successCallback, failureCallback) {
            fetch(request_calendar)
                .then(function (response) {
                    return response.json()
                })
                .then(function (data) {
                    let events = data.events.map(event => {
                        return {
                            title: event.Grupos, // o cualquier otro campo que desees mostrar como título
                            start: new Date(event.Fecha + 'T' + event.HoraInicio),
                            end: new Date(event.Fecha + 'T' + event.HoraFin)
                        };
                    });
                    successCallback(events)
                })
                .catch(function (error) {
                    failureCallback(error)
                })
        },
    });
    calendar.render();
});