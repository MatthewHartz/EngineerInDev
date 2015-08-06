app.directive("scroll", ["$window", function ($window) {
    return function (scope, element, attrs) {
        angular.element($window).bind("scroll", function () {
            if (this.pageYOffset >= 170) {
                scope.atTop = false;
            } else {
                scope.atTop = true;
            }
            scope.$apply();
        });
    };
}]);