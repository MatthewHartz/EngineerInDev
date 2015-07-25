app.controller('AboutCtrl', ['$scope', function ($scope) {
    $scope.blog = {};

    $scope.init = function () {
        $http.get('/api/blogs/aboutme')
            .success(function (blog) {
                $scope.blog = blog;
                $scope.blog['htmlBody'] = $sce.trustAsHtml(blog.content);
            }).error(function () {
                var test = '';
            });
    };

    $scope.init();
}]);