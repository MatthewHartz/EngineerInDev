app.controller('HomeCtrl', ['$scope', '$http', '$sce', function ($scope, $http, $sce) {
    $scope.blog = {};

    $scope.init = function() {
        $http.get('/api/blogs/newest')
            .success(function (blog) {
                $scope.blog = blog;
                $scope.blog['htmlBody'] = $sce.trustAsHtml(blog.content);
            }).error(function () {
                var test = '';
            });
    };

    $scope.init();
}]);