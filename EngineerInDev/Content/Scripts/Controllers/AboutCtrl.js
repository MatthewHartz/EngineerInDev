app.controller('AboutCtrl', ['$scope', '$http', '$sce', function ($scope, $http, $sce) {
    $scope.blog = {};

    $scope.init = function () {
        $http({
            url: '/api/blogs/',
            method: "GET",
            params: { name : 'About Me'}
            })
            .success(function (blog) {
                $scope.blog = blog;
                $scope.blog['htmlBody'] = $sce.trustAsHtml(blog.content);

                $scope.identifier = blog.title;
                $scope.url = 'http://localhost:60664/#!/Blogs/' + blog.title;
                $scope.contentLoaded = true;
            }).error(function () {
                var test = '';
            });
    };

    $scope.init();
}]);