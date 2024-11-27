
$(document).ready(function ()
{
    $('#calendar').fullCalendar({
        header:
        {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        buttonText: {
            today: 'today',
            month: 'month',
            week: 'week',
            day: 'day'
        },

        events: function (start, end, timezone, callback)
        {

            $.ajax({
                url: '/DashBoard/GetCalendarData',
                type: "GET",
                dataType: "JSON",

                success: function (result)
                {
                    //debugger;
                    var events = [];
                  

                   $.each(result, function (i, data)
                    {
                        events.push(
                       {
                           id: data.Transid,
                           description:data.CID,
                           title: data.Name,
                           start: moment(data.cmp1).format('YYYY-MM-DD'),
                           backgroundColor: data.color,
                           borderColor: data.color
                       });
                        
                    });
                    //events = [];
                    callback(events);
                   events = [];
                }
            });
        },

        eventRender: function (event, element)
        {
           
            element.qtip(
            {
                content: event.description
            });
        },
        eventClick: function (event) {
            window.location.href = "/ComplianceMaster/ComplianceDetail_View?SID=" + event.id + "&CID=" + event.description;
            
        },

       
        editable: false
    });
});
