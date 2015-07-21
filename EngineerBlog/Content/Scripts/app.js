var app = angular.module('engineerBlog', [
    'ngRoute',
    'textAngular'
    
]);

app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
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
        .otherwise({
            redirectTo: '/Home'
        });
}]);

app.run(['$http', function ($http) {
    // asp.net uses this header to identify ajax requests
    $http.defaults.headers.common['X-Requested-With'] = 'XMLHttpRequest';
}]);