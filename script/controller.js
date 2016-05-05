var zvikaAppControllers = angular.module('zvikaAppControllers', []);


zvikaAppControllers.controller("indexCtrl", function($scope) {
 
});

zvikaAppControllers.controller("sourcesCtrl", function($scope) {
    $scope.sourcesList = [
        {
            day: 13,
            month: "April",
            desc: "Jerusalem municipality source.",
            area: "municipality",
            price: "$00.00",
            button: "Subscribe",
            buttonClass: "btn-blue"
        },
        {
            day: 16,
            month: "March",
            desc: "JCE Azriele source.",
            area: "college",
            price: "$00.00",
            button: "unSubscribe",
            buttonClass: "btn-red"
        },
        {
            day: 26,
            month: "June",
            desc: "Licensing Department.",
            area: "vehicle",
            price: "$00.00",
            button: "Subscribe",
            buttonClass: "btn-blue"
        },
        {
            day: 10,
            month: "November",
            desc: "Leumit Health Care Services.",
            area: "National health service",
            price: "$10.00",
            button: "Subscribe",
            buttonClass: "btn-blue"
        },
        {
            day: 16,
            month: "march",
            desc: "google calendar.",
            area: "calendar service",
            price: "$00.00",
            button: "unSubscribe",
            buttonClass: "btn-red"
        },
        {
            day: 16,
            month: "march",
            desc: "Student Dani Din.",
            area: "Linear test",
            price: "$00.00",
            button: "unSubscribe",
            buttonClass: "btn-red"
        },
        {
            day: 1,
            month: "August",
            desc: "Student Zvika Yamin.",
            area: "soccer game",
            price: "$0.00",
            button: "unSubscribe",
            buttonClass: "btn-red"
        },
        {
            day: 16,
            month: "march",
            desc: "Dogy Dog veterinarian.",
            area: "Siemens Arena",
            price: "$50.00",
            button: "unSubscribe",
            buttonClass: "btn-red"
        },
       
    ];
    
    
});

zvikaAppControllers.controller("calendarCtrl", function($scope) {
    $('#calendar').fullCalendar({
			header: {
				left: 'prev,next today',
				center: 'title',
				right: 'month,agendaWeek,agendaDay'
			},
			defaultDate: '2016-05-12',
			businessHours: true, // display business hours
			editable: true,
			events: [
				{
					title: 'Business Lunch',
					start: '2016-05-03T13:00:00',
					constraint: 'businessHours'
				},
				{
					title: 'Meeting',
					start: '2016-05-13T11:00:00',
					constraint: 'availableForMeeting', // defined below
					color: '#257e4a'
				},
				{
					title: 'Conference',
					start: '2016-05-18',
					end: '2016-05-20'
				},
				{
					title: 'Party',
					start: '2016-05-29T20:00:00'
				},

				// areas where "Meeting" must be dropped
				{
					id: 'availableForMeeting',
					start: '2016-05-11T10:00:00',
					end: '2016-05-11T16:00:00',
					rendering: 'background'
				},
				{
					id: 'availableForMeeting',
					start: '2016-05-13T10:00:00',
					end: '2016-05-13T16:00:00',
					rendering: 'background'
				},

				// red areas where no events can be dropped
				{
					start: '2016-05-24',
					end: '2016-05-28',
					overlap: false,
					rendering: 'background',
					color: '#ff9f89'
				},
				{
					start: '2016-05-06',
					end: '2016-05-08',
					overlap: false,
					rendering: 'background',
					color: '#ff9f89'
				}
			]
		});

});