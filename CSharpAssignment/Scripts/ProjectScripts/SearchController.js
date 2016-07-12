app.controller('SearchController', function ($scope, $http) {

    $scope.searchCrime = function () {
        var data = {
            Age: $scope.ageRange,
            Name: $scope.searchName,
            Gender: $scope.gender,
            MinHeight: $scope.minHeight,
            MaxHeight: $scope.maxHeight,
            MinWeight: $scope.minWeight,
            MaxWeight: $scope.maxWeight,
            Nationality: $scope.nationality,
            Location: $scope.location,
            Crime: $scope.crimeType
        }
        $http({
            method: 'GET',
            url: '/home/GetCriminalSearchDetails',
            params: data
        }).success(function (response) {
            debugger;

        }).error(function (response) { });
    };

    $scope.GetLocations = function () {
        $http({
            method: 'GET',
            url: '/home/GetLocations'
        }).success(function (response) {
            $scope.locations = response;
        }).error(function (response) { });
    };

    $scope.GetCrimeTypes = function () {
        $http({
            method: 'GET',
            url: '/home/GetCrimeTypes'
        }).success(function (response) {
            $scope.crimeTypes = response;
        }).error(function (response) { });
    };

    $scope.GetLocations();
    $scope.GetCrimeTypes();
});