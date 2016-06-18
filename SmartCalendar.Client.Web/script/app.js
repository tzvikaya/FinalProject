var app = angular.module("zvikaApp", ['ngRoute', 'zvikaAppControllers']);

app.config(['$routeProvider',
    function ($routeProvider) {
        $routeProvider.
            when('/', {
                templateUrl: 'views/main.html',
                controller: 'indexCtrl'
            }).
            when('/login', {
                templateUrl: 'views/login.html',
                controller: 'loginCtrl'
            }).
            when('/register', {
                templateUrl: 'views/register.html',
                controller: 'registerCtrl'
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
    }])
 .run(function ($rootScope, $location, AuthService) {
     // register listener to watch route changes
     $rootScope.$on("$locationChangeStart", function (event, next, current) {
         console.log(AuthService.isLoggedIn());
         console.log(next);
         if (
             !AuthService.isLoggedIn()
             && next != 'http://zvikayamin.azurewebsites.net/#/'
             && next != 'http://zvikayamin.azurewebsites.net/') {
             // no logged user, we should be going to #login
             if (next.templateUrl == "views/login.html") {
                 // already going to #login, no redirect needed
             } else {
                 // not going to #login, we should redirect now
                 $location.path("/login");
             }
         }
     });
 });