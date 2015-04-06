var app = angular.module('autcompleteSample', ['ui.bootstrap']);

app.controller('autocompleteController', function ($scope, $http) {

    $scope.Items = ["test1", "test 2"];
    $scope.selected = null;

    $scope.$watch("selected", function (newValue, oldValue) {
        
        $http.post('/autocomplete/propose', { input: newValue }).
        success(function (data, status, headers, config) {
            $scope.Items = data;
        }).error(function (data, status, headers, config) {
            $scope.Items = [];
        });

    });

});