app.controller('PastCtrl', ['$scope', '$http', '$sce', function ($scope, $http, $sce) {
    $scope.blogs = {};

    $scope.goToBlog = function(name) {

    };

    $scope.init = function () {
        $http.get('/api/blogs/archive')
            .success(function (blogs) {
                $scope.archive = blogs;
            }).error(function () {
                var test = '';
            });
    };

    $scope.init();
}]);