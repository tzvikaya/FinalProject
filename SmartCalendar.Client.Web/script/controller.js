var zvikaAppControllers = angular.module('zvikaAppControllers',  []);

zvikaAppControllers.controller("indexCtrl", function ($scope, $rootScope, AuthService) {
    console.log(AuthService.isLoggedIn());
    $rootScope.isLogged = AuthService.isLoggedIn();
    console.log(AuthService.isLoggedIn());
});

zvikaAppControllers.controller("loginCtrl", function ($scope, $rootScope, $http, AuthService, $location) {
    $scope.$root.title = "Login";
    $scope.user = {};

    $scope.Login = function () {
        var config = {
            params: $scope.user
        };
        console.log($scope.user);
        console.log(config);
        $http.get("http://zvikayamin.azurewebsites.net/webapi/api/Users/", config)
        .then(function (response) {
            console.log(response);
            $scope.loginMessage = "Login success !";
            AuthService.login(response.data);
            console.log(AuthService.currentUser());
            $rootScope.isLogged = AuthService.isLoggedIn();
            $location.path("/");
        });

    }
});

zvikaAppControllers.controller("registerCtrl", function ($scope, $http) {
    $scope.$root.title = "Register";
    $scope.user = {};
    $scope.user.user_isRegistered = true;

    $scope.Register = function () {
        $scope.Message = '';
        $scope.errorMessage = '';
        $http.post(
            "http://zvikayamin.azurewebsites.net/webapi/api/Users/",
            $scope.user
        )
        .then(function (response) {
            console.log(response);
            $scope.Message = "hello " + response.data.user_firstname + " Your user id is: " + response.data.user_id + " !";

        }, function (response) {
            console.log(response);
            $scope.errorMessage = "Error: " + response.data.Message + ".";
        });

    }
});

zvikaAppControllers.controller("sourcesCtrl", function ($scope, $http, AuthService) {
    
    $scope.$root.title = "Sources";
    $scope.sourcesList = [];
    function IsSourceExist(sid) {
        for (var i = 0; i < AuthService.currentUser().Users_Sources.length; i++)
            if (AuthService.currentUser().Users_Sources[i].source_id == sid)
                return true;
        return false;
    }
    $http.get("http://zvikayamin.azurewebsites.net/webapi/api/Sources")
        .then(function (response) {
            angular.forEach(response.data, function (value, key) {
                var s = {
                    source_id: value.source_id,
                    month: "April",
                    source_name: value.source_name,
                    area: "xxxxx",
                    price: "$00.00",
                    button: IsSourceExist(value.source_id) ? "unSubscribe" : "Subscribe",
                    buttonClass: IsSourceExist(value.source_id) ? "btn-red" : "btn-blue"
                        

                }
                $scope.sourcesList.push(s);
            });
        });
    
    $scope.SourceClick = function (sid) {
        console.log(sid);
        var source = {
            source_id: sid,
            user_id: IsSourceExist(sid) ? -1 : AuthService.currentUser().user_id
        };
        AuthService.currentUser().Users_Sources.push(source);
        $http.post("http://zvikayamin.azurewebsites.net/webapi/api/UsersSources", AuthService.currentUser())
       .then(
           function (response) {
               source.dateRegistered = "2016-05-29T17:49:22.03";
               console.log(response);
               
               // success callback
           },
           function (response) {
               console.log(response);
               // failure callback
           }
        );
    };
});

zvikaAppControllers.controller("calendarCtrl", function ($scope) {
    $scope.$root.title = "Calendar";

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