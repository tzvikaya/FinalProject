var app = angular.module("zvikaApp", ['ngRoute', 'zvikaAppControllers']);

app.config(['$routeProvider',
    function($routeProvider) {
        $routeProvider.
            when('/', {
                templateUrl: 'views/main.html',
                controller: 'indexCtrl'
            }).
            when('/login', {
                templateUrl: 'views/login.html',
                controller: 'loginCtrl'
            }).
            when('/sources', {
                templateUrl: 'views/sources.html',
                controller: 'sourcesCtrl'
            }).
            when('/calendar', {
                templateUrl: 'views/calendar.html',
                controller: 'calendarCtrl'
            }).
            otherwise({
                redirectTo: '/404'
            });
    }]);