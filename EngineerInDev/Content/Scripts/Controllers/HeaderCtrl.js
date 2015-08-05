app.controller('HeaderCtrl', ['$scope', '$http', '$window', function ($scope, $http, $window) {
    $scope.search = function () {
        $window.location.href = '/Search?query=' + $scope.searchText;
    }
}]);