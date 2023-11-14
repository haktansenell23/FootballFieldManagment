
var mainCtrlModule = angular.module("mainCtrlModule", [])

mainCtrlModule.controller('mainCtrl', function ($scope, $rootScope,$timeout) {
    $rootScope.$mc ={
        domainUri: '',
        loading : true,
    }


    $rootScope.$watch("$mc.loading", function (newValue,oldValue) {

        if (newValue == true) {

            $timeout(function () {
                $rootScope.$mc.loading = false;

            },1000)

        }

    }, true)

    $scope.$on('$locationChangeSuccess', function () {
        $rootScope.$mc.loading = true;


    })
    //detect refresh event
    $scope.$on('$locationChangeStart', function () {
        $rootScope.$mc.loading = true;
    })

    $rootScope.$mc.domainUri = window.location.protocol + window.location.host;

    $scope.trying = '12';
})


mainCtrlModule.controller('loginCtrl', ['$scope', '$rootScope', function ($scope, $rootScope) {

   var homeUri=$rootScope.$mc.domainUri
    $scope.soundEnable = true;
    $scope.changeStateSound = function () {
        var audio = document.getElementById("music");
        console.log("sa");
        if ($scope.soundEnable) {
            $("#sound-button").removeClass("bi bi-volume-down-fill");
            $("#sound-button").addClass("bi bi-volume-mute-fill");

            //audio.pause()
            audio.volume = 0;
            $scope.soundEnable = !$scope.soundEnable;

        }

        else {
            $("#sound-button").removeClass("bi bi-volume-mute-fill");
            $("#sound-button").addClass("bi bi-volume-down-fill");
            $scope.soundEnable = !$scope.soundEnable;
            audio.volume = 1;
            //audio.play();

          
        }
      

    }
    $scope.changeUri = function () {
        window.location.href = "Home/SignUp"
    }

}])

mainCtrlModule.controller('signUpCtrl', ['$scope', '$rootScope', 'NotifService','$http', function ($scope, $rootScope, NotifService,$http) {

    $scope.$ns = NotifService;
    $scope.loading = $rootScope.$mc.loading;
    $scope.SignUpModel = {
        UserName:'',
        Email:'',
        Password:'',
        RePassword:'',
        Phone:'',
    }
    $scope.homeUri = $rootScope.$mc.domainUri
    $scope.soundEnable = true;
    $scope.changeStateSound = function () {
        var audio = document.getElementById("music");
        if ($scope.soundEnable) {
            $("#sound-button").removeClass("bi bi-volume-down-fill");
            $("#sound-button").addClass("bi bi-volume-mute-fill");

            //audio.pause()
            audio.volume = 0;
            $scope.soundEnable = !$scope.soundEnable;

        }

        else {
            $("#sound-button").removeClass("bi bi-volume-mute-fill");
            $("#sound-button").addClass("bi bi-volume-down-fill");
            $scope.soundEnable = !$scope.soundEnable;
            audio.volume = 1;
            //audio.play();


        }


    }
    $scope.ok = function () {



        $scope.loading = true;

        console.log("$scope.homeUri", $scope.homeUri);
        var uri = $scope.homeUri+"/Home/SignUp";
        console.log("url--->", uri);
        var uri2 = "https://localhost:7182/Home/SignUp"
        $http.post(uri2, $scope.SignUpModel).then(function (resp) {

        })


    }

}])