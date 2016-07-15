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
            LocationId: $scope.location,
            Crime: $scope.crimeType
        }
        $http({
            method: 'GET',
            url: '/home/GetCriminalSearchDetails',
            params: data
        }).success(function (response) {
            if (response === true) {
                alert('The results will be sent to your registered mail Id');
            }
            else {
                alert('No results are retrieved. Please try with different search criteria');
            }
            $scope.Reset();
        }).error(function (response) {
            $scope.Reset();
        });
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
        }).error(function (response) {
        });
    };

    $scope.Reset = function () {
        $scope.ageRange = '';
        $scope.searchName = '';
        $scope.gender = 'male';
        $scope.minHeight = '';
        $scope.maxHeight = '';
        $scope.minWeight = '';
        $scope.maxWeight = '';
        $scope.nationality = '';
        $scope.location = '';
        $scope.crimeType = '';
    };

    $scope.GetLocations();
    $scope.GetCrimeTypes();
});