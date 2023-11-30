var homeCtrlModule = angular.module("homeCtrlModule", [])


homeCtrlModule.controller("mainLayoutCtrl", ["$scope", "$rootScope", "$http", function ($scope,$rootScope,$http) {

    angular.element(document).ready(function () {

        $http.get(homeUri + "api/GetRapidApiKey").then(function (resp) {

            $rootScope.$mc.rapidKey = resp.data;
        })


        

    });

}])


homeCtrlModule.controller("homePageCtrl", ["$scope,$rootScope,$http", function ($scope,$rootScope,$http) {



    angular.element(document).ready(function () {



    




    })



}])