
var mainCtrlModule = angular.module("mainCtrlModule", [])

mainCtrlModule.controller('mainCtrl', function ($scope, $rootScope,$timeout,$interval) {
    $rootScope.$mc ={
        domainUri: '',
        loading: true,
    
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

    //$rootScope.$mc.domainUri = window.location.host;




})



mainCtrlModule.controller('loginCtrl', ['$scope', '$rootScope', function ($scope, $rootScope) {
    $scope.loading = $rootScope.$mc.loading;
   var homeUri=$rootScope.$mc.domainUri
    $scope.soundEnable = false;
    $scope.changeStateSound = function () {
        var audio = document.getElementById("loginMusic");
        if ($scope.soundEnable) {
            $("#sound-button").removeClass("bi bi-volume-down-fill");
            $("#sound-button").addClass("bi bi-volume-mute-fill");

            //audio.pause()
            audio.volume = 0;
            $scope.soundEnable = !$scope.soundEnable;
            console.log("window.console", window.console);


        }

        else {
            $("#sound-button").removeClass("bi bi-volume-mute-fill");
            $("#sound-button").addClass("bi bi-volume-down-fill");
            $scope.soundEnable = !$scope.soundEnable;
            audio.volume = 1;
            //audio.play();
        }
      

    }

    angular.element(document).ready(function () {
        $scope.kk = function () {

        }
        console.log("test", $scope.test);
        $scope.kk();

    })


}])

mainCtrlModule.controller('signUpCtrl', ['$scope', '$rootScope', 'NotifService','$http','$timeout',function ($scope, $rootScope, NotifService,$http,$timeout) {

    $scope.$ns = NotifService;
    $scope.loading = $rootScope.$mc.loading;
    $scope.SignUpModel = {
        UserName:'',
        Email:'',
        Password:'',
        RePassword:'',
        Phone:'',
    }
    $scope.soundEnable = true;
    $scope.changeStateSound = function () {
        var audio = document.getElementById("signUpAudio");
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
        var requestUri = homeUri + "Home/SignUp/";
        $http.post(requestUri, $scope.SignUpModel).then(function (resp) {
            if (resp.data.statu) {


                $scope.$ns.notification(resp.data.title, resp.data.message, resp.data.buttonText, resp.data.statu);

                console.log("SignUpModel", $scope.SignUpModel);
                $rootScope.$mc.login = {
                    email: $scope.SignUpModel.email,
                    password:$scope.SignUpModel.password
                }
             
                location.href = homeUri;

            } else {
                $scope.$ns.notification(resp.data.title, resp.data.message, resp.data.buttonText, resp.data.statu);
            }


        }).catch(function (error) {

            console.error(error);
        })



    }

}])