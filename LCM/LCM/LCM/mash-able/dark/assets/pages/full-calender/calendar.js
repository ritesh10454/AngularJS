"use strict"; $(document).ready(function () {
    $('#external-events .fc-event').each(function () {
        $(this).data('event', { title: $.trim($(this).text()), stick: true });
        $(this).draggable({ zIndex: 999, revert: true, revertDuration: 0 });
    }); $('#calendar').fullCalendar({
        header: { left: 'prev,next today', center: 'title', right: 'month,agendaWeek,agendaDay,listMonth' },
        defaultDate: '2016-09-12', navLinks: true, businessHours: true, editable: true, droppable: true, drop: function () {
            if ($('#checkbox2').is(':checked')) { $(this).remove(); }
        }, events: [
            { title: 'Sam Lunch', start: '2016-09-03T13:00:00', constraint: 'businessHours' },
            { title: 'Meeting', start: '2016-09-13T11:00:00', constraint: 'availableForMeeting', editable: true, borderColor: '#1abc9c', textColor: '#000' },
            { title: 'Conference', start: '2016-09-18', end: '2016-09-20' },
            { title: 'Party', start: '2016-09-29T20:00:00' },
            { id: 'availableForMeeting', start: '2016-09-11T10:00:00', end: '2016-09-11T16:00:00', rendering: 'background' },
            { id: 'availableForMeeting', start: '2016-09-13T10:00:00', end: '2016-09-13T16:00:00', rendering: 'background' },
            { start: '2016-09-24', end: '2016-09-28', overlap: false, rendering: 'background', color: '#d8d6d6' },
            { start: '2016-09-06', end: '2016-09-08', overlap: false, rendering: 'background', color: '#d8d6d6' }]
    });
});