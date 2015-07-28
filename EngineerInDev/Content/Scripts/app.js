var app = angular.module('engineerBlog', [
    'ngRoute',
    'textAngular',
    'angularUtils.directives.dirDisqus'
]);

app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider
        .when('/', {
            templateUrl: '/Home/Template/' + 'Index',
            controller: 'HomeCtrl',
            caseInsensitiveMatch: true
        })
        .when('/Home/', {
            templateUrl: '/Home/Template/' + 'Index',
            controller: 'HomeCtrl',
            caseInsensitiveMatch: true
        })
        .when('/About/', {
            templateUrl: '/Home/Template/About',
            caseInsensitiveMatch: true,
            controller: 'AboutCtrl'
        })
        .when('/Blogs/:blogName', {
            templateUrl: '/Home/Template/Blog',
            caseInsensitiveMatch: true,
            controller: 'BlogCtrl'
        })
        .otherwise({
            controller: function () {
                window.location.replace('/');
            },
            template: "<div></div>"
        });

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: true
    });
}]);

app.run(['$http', function ($http) {
    // asp.net uses this header to identify ajax requests
    $http.defaults.headers.common['X-Requested-With'] = 'XMLHttpRequest';
}]);