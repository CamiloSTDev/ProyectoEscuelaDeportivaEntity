
//import { req } from 'superagent';
//var request_calendar = localStorage.getItem('request_calendar');

//if (!request_calendar) {
//    $.ajax({
//        url: '/api/horarios',
//        type: 'GET'
//    }).done(function (data) {
//        request_calendar = data;
//        localStorage.setItem('request_calendar', JSON.stringify(request_calendar));
//        console.log(request_calendar); // Verificar que se haya almacenado correctamente
//    });
//} else {
//    request_calendar = JSON.parse(request_calendar);
//    console.log(request_calendar); // Verificar que se haya recuperado correctamente
/*}*/
document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');

    var calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        initialDate: '2024-05-07',
        headerToolbar: {
            left: 'prev,next today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,timeGridDay'
        },
        events: [
            {
                id: 111,
                title: "MiniTenis",
                start: "2024-06-01T10:00:00",
                end: "2024-06-01T12:00:00",
                backgroundColor: "blue"


            },
            {
                id:222,
                title: "Juvenil",
                start: "2024-06-01T12:00:00",
                end: "2024-06-01T14:00:00"
            },
            {
                id:333,
                title: "Intermedio",
                start: "2024-06-01T14:00:00",
                end: "2024-06-01T16:00:00"
            },
            {
                id: 444,
                title: "Avanzado",
                start: "2024-06-01T16:00:00",
                end: "2024-06-01T18:00:00"
            }
        ]
    });

    calendar.render();
});