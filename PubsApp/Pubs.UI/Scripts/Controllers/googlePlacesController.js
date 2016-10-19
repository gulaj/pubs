﻿pubApp.controller('googlePlacesController', ['$scope', '$http', 'NgMap', function ($scope, $http, NgMap) {
        $scope.radius = 2;

        $scope.poiTypes = [
            {
                type: "bar",
                name: "Bars & Pubs",
            },
            {
                type: "meal_delivery",
                name: "Meal delivery",
            },
            {
                type: "meal_takeaway",
                name: "Meal Takeaway",
            },
            {
                type: "cafe",
                name: "Cafe",
            },
            {
                type: "night_club",
                name: "Night club",
            },
            {
                type: "casino",
                name: "Casino",
            },
            {
                type: "night_club",
                name: "Night club",
            }
        ];

       
        $scope.selectedPoiTypes = [];
        $scope.selectedRadius = $scope.radius;
        
        $scope.poiList = [];

        function poiDetails(data) {
            $scope.poiList = [];
            if (data.length > 0) {
                $scope.latitude = data[0].geometry.location.lat;
                $scope.longitude = data[0].geometry.location.lng;
            }
                data.forEach(function (value) {
                var locationData = {
                    id: value.id,
                    location: value.geometry.location,
                    name: value.name,
                    address: value.vicinity ? value.vicinity : value.formatted_address,
                    rating: value.rating ? value.rating : "N/A",
                    icon: {
                        url: value.icon,
                        scaledSize: [32, 32],
                    }
                }
                $scope.poiList.push(locationData);
            });
        }

       
        $scope.searchPlaces = function () {
            var poiTypes = $scope.selectedPoiTypes.map(function (item) {
                return item.type;
            }).join("|");
                
            $scope.error = "";

            //var findNearestUri = apiUrlPattern.replace("{types}", poiTypes).replace("{radius}", $scope.selectedRadius * 1000).replace("{lat}", $scope.lat).replace("{lng}", $scope.lng);

            var findNearestUri = 'http://localhost/Pubs.WebApi/api/Places/Find/Nearest/';
            var params = {
                Radius: $scope.selectedRadius * 1000,
                Latitude: $scope.lat,
                Longitude: $scope.lng,
                Types: poiTypes

            }
            $http({
                method: 'GET',
                url: findNearestUri,
                params: params,
            }).then(function (response) {
                poiDetails(response.data);
            }, function (response) {
                $scope.error = "Can not find anything at your location.";
            });
        }

        function setDefaultLocation() {
            $http({
                method: 'GET',
                url: 'http://localhost/Pubs.WebApi/api/Location/DefaultLocation',
            }).then(function (response) {
                $scope.lat = response.data.Latitude;
                $scope.lng = response.data.Longitude;
            }, function () {
                $scope.error = "Default location is not available";
            });
        }

        function getCurrentLocation(location) {
            $scope.lat = location.coords.latitude;
            $scope.lng = location.coords.longitude;
        }
       
        if (navigator.geolocation) {
            var location = navigator.geolocation.getCurrentPosition(getCurrentLocation, setDefaultLocation());

        }
        else {
            setDefaultLocation();
        }
        
        $scope.selectedPoi = {};
        $scope.showDetails = function (e, poi) {
            $scope.selectedPoi = poi;
            $scope.map.showInfoWindow('info-window', poi.id);
        };
    }]);
